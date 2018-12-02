using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public int Available { get; set; }
        public int StockInQuantity { get; set; }
        public int StockOutQuantity { get; set; }

        //public Item Items { get; set; }
    }
}