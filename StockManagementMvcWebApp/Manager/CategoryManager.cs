using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Manager
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        public string SaveCategory(Category category)
        {
            bool hasRow = aCategoryGateway.CheckCategory(category);

            if (!hasRow)
            {
                int rowAffected = aCategoryGateway.SaveCategory(category);

                if (rowAffected > 0)
                {
                    return "Category saved";
                }
                else
                {
                    return "Category save failed";
                }
            }
            return "Category with the same name already exists";
        }

        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();
        }
    }
}