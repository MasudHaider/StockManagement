using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class StockOut
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public double Available { get; set; }
        public double StockOutQuantity { get; set; }
    }
}