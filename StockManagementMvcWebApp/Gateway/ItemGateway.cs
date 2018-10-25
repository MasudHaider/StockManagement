using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Gateway
{
    public class ItemGateway : ParentGateway
    {
        public bool CheckItem(Item item)
        {
            Query = "SELECT * FROM ItemSetup WHERE ItemName = @ItemName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("ItemName", item.ItemName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public int Save(Item item)
        {
            Query = "INSERT INTO ItemSetup (CategoryId, CompanyId, ItemName, ReorderLevel) VALUES(@CategoryId, @CompanyId, @ItemName, @ReorderLevel)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CategoryId", item.CategoryId);
            Command.Parameters.AddWithValue("CompanyId", item.CompanyId);
            Command.Parameters.AddWithValue("ItemName", item.ItemName);
            Command.Parameters.AddWithValue("ReorderLevel", item.ReorderLevel);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Item> GetAllItems()
        {
            Query = "SELECT * FROM ItemSetup";
            Command = new SqlCommand(Query, Connection);

            List<Item> items = new List<Item>();

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Item anItem = new Item()
                {
                    ItemId = Convert.ToInt32(Reader["ItemId"]),
                    ItemName = Reader["ItemName"].ToString(),
                    ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]),
                    Available = (double)Reader["Available"]
                };
                items.Add(anItem);
            }
            Reader.Close();
            Connection.Close();

            return items;
        }

        public int UpdateAvailableData(Item availableData)
        {
            Query = "UPDATE ItemSetup SET Available =" + availableData + "WHERE ItemId =" + availableData.ItemId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}