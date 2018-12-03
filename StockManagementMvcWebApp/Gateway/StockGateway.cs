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

            Query = "INSERT INTO StockIn (CompanyId, ItemId,ReorderLevel,Available, StockInQuantity,Date)" +
                    " VALUES(@CompanyId, @ItemId,@ReorderLevel,@Available, @StockInQuantity,@Date)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CompanyId", stockIn.CompanyId);
            Command.Parameters.AddWithValue("ItemId", stockIn.ItemId);
            Command.Parameters.AddWithValue("ReorderLevel", stockIn.ReorderLevel);
            Command.Parameters.AddWithValue("Available", stockIn.Available + stockIn.StockInQuantity);
            Command.Parameters.AddWithValue("StockInQuantity", stockIn.StockInQuantity);
            Command.Parameters.AddWithValue("Date", stockIn.Date);

            Connection.Open();
            int rowAffectedInSaveStockIn = Command.ExecuteNonQuery();
            Connection.Close();

            Query = "UPDATE ItemSetup SET Available = @Available, ReorderLevel = @ReorderLevel WHERE Id = @ItemId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Available", stockIn.Available + stockIn.StockInQuantity);
            Command.Parameters.AddWithValue("ReorderLevel", stockIn.ReorderLevel+1);
            Command.Parameters.AddWithValue("ItemId", stockIn.ItemId);

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
            Query = "INSERT INTO StockSetup (CompanyId, Id, StockOutQuantity) VALUES(@CompanyId, @Id, @StockOutQuantity)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("CompanyId", stockOut.CompanyId);
            Command.Parameters.AddWithValue("Id", stockOut.ItemId);
            Command.Parameters.AddWithValue("StockInQuantity", stockOut.StockOutQuantity);

            Connection.Open();
            int rowAffectedInSaveStockOut = Command.ExecuteNonQuery();
            Connection.Close();

            Query = "UPDATE ItemSetup SET Available = " + (stockOut.Available - stockOut.StockOutQuantity) +
                    " WHERE Id = " + stockOut.ItemId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInItemSetup = Command.ExecuteNonQuery();
            Connection.Close();

            return new List<int>()
            {
                rowAffectedInSaveStockOut, rowAffectedInItemSetup
            };
        }

       /* public List<SalesView> GetStockInformation()
        {
            Query = "SELECT * FROM StockSummary";
            Command = new SqlCommand(Query, Connection);

            List<SalesView> stockSummaries = new List<SalesView>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                stockSummaries.Add(new SalesView
                {
                    ItemId = Convert.ToInt32(Reader["Id"]),
                    ItemName = Reader["Name"].ToString(),
                    CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                    CompanyName = Reader["CompanyName"].ToString(),
                    StockOutQuantity = (double)Reader["StockOutQuantity"]
                });
            }

            Reader.Close();
            Connection.Close();
            return stockSummaries;
        }
*/

        public int StockOut_SaveAll(List<StockOut> stockOutList)
        {
            
            foreach (var stock in stockOutList)
            {
                Query = "INSERT INTO StockOut (CompanyId, ItemId,ReorderLevel,Available,ActionType, StockOutQuantity,Date)" +
                    " VALUES(@CompanyId, @ItemId,@ReorderLevel,@Available,@ActionType, @StockOutQuantity,@Date)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("CompanyId", stock.CompanyId);
                Command.Parameters.AddWithValue("ItemId", stock.ItemId);
                Command.Parameters.AddWithValue("ReorderLevel", stock.ReorderLevel);
                Command.Parameters.AddWithValue("Available", stock.Available - stock.StockOutQuantity);
                Command.Parameters.AddWithValue("ActionType", stock.ActionType);
                Command.Parameters.AddWithValue("StockOutQuantity", stock.StockOutQuantity);
                Command.Parameters.AddWithValue("Date", stock.Date);

                Connection.Open();
                int rowAffectedInSaveStockIn = Command.ExecuteNonQuery();
                Connection.Close();

                Query = "UPDATE ItemSetup SET Available = @Available WHERE Id = @ItemId";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Available", stock.Available - stock.StockOutQuantity);
 
                Command.Parameters.AddWithValue("ItemId", stock.ItemId);

                Connection.Open();
                int rowAffectedInItemSetup = Command.ExecuteNonQuery();
                Connection.Close();

                if (rowAffectedInItemSetup <= 0 || rowAffectedInItemSetup <= 0)
                {
                    return -1;
                }
            }

            return 1;
        }
    }
}
