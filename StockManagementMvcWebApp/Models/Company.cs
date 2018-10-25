using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockManagementMvcWebApp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Please enter a company name")]
        public string CompanyName { get; set; }  
    }
}