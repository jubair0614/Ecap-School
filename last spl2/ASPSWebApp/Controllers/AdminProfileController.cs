using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPSDAL;
using ASPSWebApp.BusinessCode;

namespace ASPSWebApp.Controllers
{
    public class AdminProfileController : Controller
    {
        private AdminRepository adminRepository = new AdminRepository();
        Admin _admin = (Admin)System.Web.HttpContext.Current.Session["Admin"];
        // GET: AdminProfile
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            _admin = new AdminRepository().GetAdminByEmail(_admin.AdminEmail);
            return View(_admin);
        }

        // GET: AdminProfile/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit()
        {
            if (this._admin.AdminEmail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin currentAadmin = adminRepository.GetAdminByEmail(_admin.AdminEmail);
            if (currentAadmin == null)
            {
                return HttpNotFound();
            }
            return View(_admin);
        }

        // POST: AdminProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "AdminID,AdminEmail,Name,Password,Address,Religion,BloodGroup,Gender,MobileNumber")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                adminRepository.EditAdmin(admin);
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //Get
        [Authorize(Roles = "Admin")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ChangePassword(string newPassword, string confirmPassword)
        {
            Password password = new Password();
            if (password.ComparePassword(newPassword, confirmPassword))
            {
                Admin temp = adminRepository.GetAdminByEmail(_admin.AdminEmail);
                temp.Password = newPassword;
                adminRepository.EditAdmin(temp);
            }
            return RedirectToAction("Index");
        }
    }
}