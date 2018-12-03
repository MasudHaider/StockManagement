using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Gateway
{
    public class SalesViewGateway:ParentGateway
    {
        public List<SalesView> GetSalesBetweenDate(string fromDate, string toDate)
        {
            Query = "SELECT ItemName, SUM(Quantity) as Quantity FROM SalesView WHERE Date" +
                    " BETWEEN @fromDate AND @toDate GROUP BY ItemName ORDER BY ItemName";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("fromDate", fromDate);
            Command.Parameters.AddWithValue("toDate", toDate);

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<SalesView> aSalesViews = null;
            if (Reader.HasRows)
            {
                aSalesViews = new List<SalesView>();

                while (Reader.Read())
                {
                    aSalesViews.Add(new SalesView()
                    {
                        ItemName = Reader["ItemName"].ToString(),
                        Quantity = Convert.ToInt32(Reader["Quantity"])
                        
                    });

                }
            }
            Reader.Close();
            Connection.Close();

            return aSalesViews;

        }
    }
}