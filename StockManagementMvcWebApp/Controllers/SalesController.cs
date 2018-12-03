using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Manager;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Seles/

        SalesViewManager aSalesViewManager = new SalesViewManager();
        public ActionResult SalesView()
        {
            return View();
        }

        public JsonResult GetSalesBetweenDate(string fromDate, string toDate)
        {
            List<SalesView> aSalesViews = aSalesViewManager.GetSalesBetweenDate(fromDate, toDate);
            return Json(aSalesViews);
        }
	}
}