using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models.View
{
    public class SalesView
    {
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        [Required(ErrorMessage = "Please Select From Date")]
        public string FromDate { get; set; }
        [Required(ErrorMessage = "Please Select To Date")]
        public string ToDate { get; set; }


    }
}