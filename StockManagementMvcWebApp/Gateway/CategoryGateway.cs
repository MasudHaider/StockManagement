using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Gateway
{
    public class CategoryGateway : ParentGateway
    {
        public bool CheckCategory(Category category)
        {
            Query = "SELECT * FROM CategorySetup WHERE CategoryName = @category";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("category", category.CategoryName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public int SaveCategory(Category category)
        {
            Query = "INSERT INTO CategorySetup VALUES(@CategoryName)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CategoryName", category.CategoryName);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Category> GetAllCategories()
        {
            Query = "SELECT * FROM CategorySetup";
            Command = new SqlCommand(Query, Connection);

            List<Category> categories = new List<Category>();

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Category category = new Category()
                {
                    CategoryId = Convert.ToInt32(Reader["CategoryId"]),
                    CategoryName = Reader["CategoryName"].ToString()
                };
                categories.Add(category);
            }
            Reader.Close();
            Connection.Close();

            return categories;
        }
    }
}