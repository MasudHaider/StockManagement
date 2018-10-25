using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public float StockInQuantity { get; set; }
        public float StockOutQuantity { get; set; }

        public Item Items { get; set; }
    }
}