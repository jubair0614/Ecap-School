using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBazarDAL;

namespace OnlineBazarWebApp.Controllers
{
    public class ProductCatagoryController : Controller
    {
        ProductCategoryRepository productCategoryRepository = new ProductCategoryRepository();
        // GET: ProductCatagory
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = productCategoryRepository.GetProductCategoryList();
            return View(productCategories);
        }

        // GET: ProductCatagory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCatagory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCatagory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCatagory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCatagory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCatagory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCatagory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
