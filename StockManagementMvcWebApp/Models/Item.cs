using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "please select a category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "please select a company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Please enter an item name")]
        public string ItemName { get; set; }

        public int ReorderLevel { get; set; }

        public float ItemSold { get; set; }
        public float ItemDamaged { get; set; }
        public float ItemLost { get; set; }
        public double Available { get; set; }
    }
}