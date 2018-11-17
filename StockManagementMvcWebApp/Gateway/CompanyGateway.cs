using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Gateway
{
    public class CompanyGateway : ParentGateway
    {
        public bool CheckCompany(Company company)
        {
            Query = "SELECT * FROM CompanySetup WHERE CompanyName = @company";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("company", company.CompanyName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public int SaveCompany(Company company)
        {
            Query = "INSERT INTO CompanySetup VALUES(@CompanyName)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CompanyName", company.CompanyName);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }

        public List<Company> GetAllCompanies()
        {
            Query = "SELECT * FROM CompanySetup";
            Command = new SqlCommand(Query, Connection);

            List<Company> companies = new List<Company>();

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Company company = new Company()
                {
                    CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                    CompanyName = Reader["CompanyName"].ToString()
                };
                companies.Add(company);
            }
            Reader.Close();
            Connection.Close();

            return companies;
        }
    }
}