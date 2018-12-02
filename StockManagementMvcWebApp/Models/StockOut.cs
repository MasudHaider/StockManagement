using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class StockOut
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please select a company")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "please select an item")]
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public int Available { get; set; }
        [Required(ErrorMessage = "Please enter stockout quantit number")]
        public string ActionType { get; set; }

        public int StockOutQuantity { get; set; }

        public string Date { get; set; }

    }
}