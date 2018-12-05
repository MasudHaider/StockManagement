using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementMvcWebApp.Manager;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Controllers
{
    public class CompanyController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();

/*        [HttpGet]*/
        public ActionResult CompanySave()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult CompanySave(Company company)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aCompanyManager.SaveCompany(company);
            }
            ViewBag.Message = message;
            return View();
        }*/

        public JsonResult Company_Save(Company company)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aCompanyManager.SaveCompany(company);
            }
            List<Company> companies = aCompanyManager.GetAllCompanies();
            return Json(new {data = companies, mess = message});
        }



        public ActionResult ViewCompanies()
        {
            List<Company> companies = aCompanyManager.GetAllCompanies();
            ViewBag.Companies = companies;
            return View();
        }


        public JsonResult GetAllCompanies()
        {
            List<Company> companies = aCompanyManager.GetAllCompanies();
            return Json(companies);
        }
	}
}