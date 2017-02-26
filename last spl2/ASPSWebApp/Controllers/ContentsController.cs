using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPSDAL;

namespace ASPSWebApp.Controllers
{
    public class ContentsController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository();
        private ContentRepository contentRepository = new ContentRepository();
        private Student _student = (Student)System.Web.HttpContext.Current.Session["Student"];

        // GET: Contents
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult Index(string type, string description, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/File"), fileName);
                    string extension = Path.GetExtension(path);
                    string convensionName = "";
                    if (fileName.Contains(convensionName))
                    {
                        if (extension == ".pdf" || extension == ".zip" || extension == ".txt")
                        {
                            file.SaveAs(path);
                        }
                        else
                        {
                            ViewBag.error = "only pdf, zip and text are allowed";
                            return RedirectToAction("Index", "Contents");
                        }
                    }
                    else
                    {
                        ViewBag.error = "File naming convension error";
                        return RedirectToAction("Index", "Contents");
                    }
                    Content content = new Content();
                    content.StudentID = _student.StudentID;
                    content.ContentType = type;
                    content.ContentDescription = description;
                    content.ContentPath = fileName;
                    contentRepository.AddContent(content);
                }
                ViewBag.Message = "Upload Successful";
            }

            catch (Exception)
            {
                
                throw;
            }

            return RedirectToAction("Index", "StudentProfile");
        }
    }
}