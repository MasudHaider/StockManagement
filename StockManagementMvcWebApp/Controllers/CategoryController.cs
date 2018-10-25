using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementMvcWebApp.Manager;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager aCategoryManager = new CategoryManager();
        [HttpGet]
        public ActionResult CategorySave()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategorySave(Category category)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aCategoryManager.SaveCategory(category);
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ViewCategories()
        {
            List<Category> categories = aCategoryManager.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }
	}
}