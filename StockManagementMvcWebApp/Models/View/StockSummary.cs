using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models.View
{
    public class StockSummary
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double Available { get; set; }
        public int ReorderLevel { get; set; }
        public double StockInQuantity { get; set; }
        public double StockOutQuantity { get; set; }
    }
}