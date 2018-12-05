using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementMvcWebApp.Manager;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Controllers
{
    public class ItemController : Controller
    {
        ItemManager aItemManager = new ItemManager();
        CategoryManager aCategoryManager = new CategoryManager();
        CompanyManager aCompanyManager = new CompanyManager();

        /*[HttpGet]*/
        public ActionResult ItemSave()
        {
            ViewBag.Categories = aCategoryManager.GetAllCategories();
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemSave(Item item)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aItemManager.SaveItem(item);
                ViewBag.Message = message;
            }

            ViewBag.Categories = aCategoryManager.GetAllCategories();
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            return View();
        }*/


        public JsonResult Item_Save(Item item)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aItemManager.SaveItem(item);
                ViewBag.Message = message;
            }

            return Json(message);
        }

        /*[HttpGet]*/
        public ActionResult ItemSearchAndView()
        {
            ViewBag.Categories = aCategoryManager.GetAllCategories();
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            return View();
        }

        

/*        [HttpPost]
        [ValidateAntiForgeryToken]*/
        public JsonResult ItemSearchView(int? CompanyId, int? CategoryId)
        {

            List<Item> items = aItemManager.GetItemsByCompanyCategory(CompanyId, CategoryId);

            ViewBag.Categories = aCategoryManager.GetAllCategories();
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            return Json(items);
        }

       
    }
}