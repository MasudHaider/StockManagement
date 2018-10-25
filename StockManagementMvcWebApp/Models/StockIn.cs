using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class StockIn
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public double Available { get; set; }
        public double StockInQuantity { get; set; }
    }
}