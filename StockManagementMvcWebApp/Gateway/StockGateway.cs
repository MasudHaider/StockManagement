using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementMvcWebApp.Models;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Gateway
{
    public class StockGateway : ParentGateway
    {
        private Item anItem = new Item();
        public List<int> SaveStockIn(StockIn stockIn)
        {
            
            Query = "INSERT INTO StockSetup (CompanyId, ItemId, StockInQuantity) VALUES(@CompanyId, @ItemId, @StockInQuantity)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CompanyId", stockIn.CompanyId);
            Command.Parameters.AddWithValue("ItemId", stockIn.ItemId);
            Command.Parameters.AddWithValue("StockInQuantity", stockIn.StockInQuantity);

            Connection.Open();
            int rowAffectedInSaveStockIn = Command.ExecuteNonQuery();
            Connection.Close();

            Query = "UPDATE ItemSetup SET Available = " + (stockIn.Available + stockIn.StockInQuantity) +
                    " WHERE ItemId = " + stockIn.ItemId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInItemSetup = Command.ExecuteNonQuery();
            Connection.Close();

            return new List<int>()
            {
                rowAffectedInSaveStockIn, rowAffectedInItemSetup
            };
        }

        public List<int> SaveStockOut(StockOut stockOut)
        {
            Query = "INSERT INTO StockSetup (CompanyId, ItemId, StockOutQuantity) VALUES(@CompanyId, @ItemId, @StockOutQuantity)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CompanyId", stockOut.CompanyId);
            Command.Parameters.AddWithValue("ItemId", stockOut.ItemId);
            Command.Parameters.AddWithValue("StockInQuantity", stockOut.StockOutQuantity);

            Connection.Open();
            int rowAffectedInSaveStockOut = Command.ExecuteNonQuery();
            Connection.Close();

            Query = "UPDATE ItemSetup SET Available = " + (stockOut.Available - stockOut.StockOutQuantity) +
                    " WHERE ItemId = " + stockOut.ItemId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInItemSetup = Command.ExecuteNonQuery();
            Connection.Close();

            return new List<int>()
            {
                rowAffectedInSaveStockOut, rowAffectedInItemSetup
            };
        }

        public List<StockSummary> GetStockInformation()
        {
            Query = "SELECT * FROM StockSummary";
            Command = new SqlCommand(Query, Connection);

            List<StockSummary> stockSummaries = new List<StockSummary>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                stockSummaries.Add(new StockSummary
                {
                    ItemId = Convert.ToInt32(Reader["ItemId"]),
                    ItemName = Reader["ItemName"].ToString(),
                    CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                    CompanyName = Reader["CompanyName"].ToString(),
                    StockOutQuantity = (double)Reader["StockOutQuantity"]
                });
            }

            Reader.Close();
            Connection.Close();
            return stockSummaries;
        }

        
    }
}
