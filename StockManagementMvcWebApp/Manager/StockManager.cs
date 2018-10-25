using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Models;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Manager
{
    public class StockManager
    {
        StockGateway aStockGateway = new StockGateway();
        public string SaveStockIn(StockIn stockIn)
        {

            var rowAffected = aStockGateway.SaveStockIn(stockIn);
            if (rowAffected[0] > 0 && rowAffected[1] > 0)
            {
                return "Stock In is successfull";
            }
            return "stockIn in failed";
        }

        //public string SaveStockOut(StockOut stockOut)
        //{
        //    var rowAffected = aStockGateway.SaveStockOut(stockOut);
        //    if (rowAffected )
        //    {
                
        //    }
        //}

        public List<StockSummary> GetStockInformation()
        {
            List<StockSummary> stockSummaries = aStockGateway.GetStockInformation();
            return stockSummaries;
        }
    }
}