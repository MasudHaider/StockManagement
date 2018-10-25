using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Manager
{
    public class ItemManager
    {
        ItemGateway aItemGateway = new ItemGateway();
        public string SaveItem(Item item)
        {
            bool hasRow = aItemGateway.CheckItem(item);

            if (!hasRow)
            {
                int rowAffected = aItemGateway.Save(item);

                if (rowAffected > 0)
                {
                    return "Item is saved succesfully";
                }
                return "item can't be saved";
            }

            return "Item with the same name already exists";
        }

        public List<Item> GetAllItems()
        {
            return aItemGateway.GetAllItems();
        }

        public string UpdateAvailableData(Item availableData)
        {
            int rowAffected = aItemGateway.UpdateAvailableData(availableData);
            if (rowAffected > 0)
            {
                return "Saved";
            }
            return "Failed";
        }
    }
}