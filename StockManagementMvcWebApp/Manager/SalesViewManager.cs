using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Manager
{
    public class SalesViewManager
    {
        public List<SalesView> GetSalesBetweenDate(string fromDate, string toDate)
        {
            
            SalesViewGateway aSalesViewGateway = new SalesViewGateway();

            return aSalesViewGateway.GetSalesBetweenDate(fromDate, toDate);
        }
    }
}