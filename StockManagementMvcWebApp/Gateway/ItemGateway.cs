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
            Query = "SELECT * FROM ItemSetup WHERE Name = @Name AND CompanyId = @CompanyId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", item.Name);
            Command.Parameters.AddWithValue("CompanyId", item.CompanyId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public int Save(Item item)
        {
            Query = "INSERT INTO ItemSetup (CategoryId, CompanyId, Name, ReorderLevel,Sold,Damaged,Lost,Available)" +
                    " VALUES(@CategoryId, @CompanyId, @Name, @ReorderLevel,@Sold,@Damaged,@Lost,@Available)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CategoryId", item.CategoryId);
            Command.Parameters.AddWithValue("CompanyId", item.CompanyId);
            Command.Parameters.AddWithValue("Name", item.Name);
            Command.Parameters.AddWithValue("ReorderLevel", item.ReorderLevel);
            Command.Parameters.AddWithValue("Sold", 0);
            Command.Parameters.AddWithValue("Damaged", 0);
            Command.Parameters.AddWithValue("Lost", 0);
            Command.Parameters.AddWithValue("Available", 0);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Item> GetAllItems()
        {
            Query = "SELECT * FROM ItemSetup";
            Command = new SqlCommand(Query, Connection);

            List<Item> items = null;

            

            Connection.Open();

            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                items = new List<Item>();
                while (Reader.Read())
                {
                    Item anItem = new Item()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Reader["Name"].ToString(),
                        ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]),
                        //Available = (double)Reader["Available"],
                        CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"])
                        
                        
                    };
                    items.Add(anItem);
                }
            }
            
            Reader.Close();
            Connection.Close();

            return items;
        }

        public int UpdateAvailableData(Item availableData)
        {
            Query = "UPDATE ItemSetup SET Available =" + availableData + "WHERE Id =" + availableData.Id;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Item> GetItemsByCompanyCategory(int? companyId, int? categoryId)
        {

            Query = "SELECT * FROM ItemSetup WHERE CompanyId = @companyId AND CategoryId = @categoryId";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("companyId", companyId);
            Command.Parameters.AddWithValue("categoryId", categoryId);


            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Item> items = null;

            if (Reader.HasRows)
            {
                items = new List<Item>();
                while (Reader.Read())
                {
                    Item anItem = new Item()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Reader["Name"].ToString(),
                        ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]),
                        //Available = (double)Reader["Available"],
                        CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"])


                    };
                    items.Add(anItem);
                }
            }
            return items;
        }
    }
}