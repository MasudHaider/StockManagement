using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Gateway;
using StockManagementMvcWebApp.Models;

namespace StockManagementMvcWebApp.Manager
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
        public string SaveCompany(Company company)
        {
            bool hasRow = aCompanyGateway.CheckCompany(company);

            if (!hasRow)
            {
                int rowAffected = aCompanyGateway.SaveCompany(company);

                if (rowAffected > 0)
                {
                    return "Company Saved Successfully";
                }
                return "Company save failed";
            }
            return "Company with the same name already exists";
        }

        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetAllCompanies();
        }
    }
}