using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.Sillicon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SHikkhanobishAPI.Controllers
{
    public class SiliconController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response IssueVoucer(IssueVoucher iv)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetIssueVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IssueVoucherID", iv.IssueVoucherID);
                cmd.Parameters.AddWithValue("@IssueVoucherDate", iv.IssueVoucherDate);
                cmd.Parameters.AddWithValue("@itemNumber", iv.itemNumber);
                cmd.Parameters.AddWithValue("@description", iv.description);
                cmd.Parameters.AddWithValue("@IssueQuantity", iv.IssueQuantity);
                cmd.Parameters.AddWithValue("@wareHouseID", iv.wareHouseID);
                cmd.Parameters.AddWithValue("@workOrderNo", iv.workOrderNo);
                cmd.Parameters.AddWithValue("@Condition", iv.Condition);
                cmd.Parameters.AddWithValue("@contructorName", iv.contructorName);
                cmd.Parameters.AddWithValue("@requisition", iv.requisition);
                cmd.Parameters.AddWithValue("@wareHouseName", iv.wareHouseName);
               


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response RemoveIssueVoucher(IssueVoucher iv)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.RemoveVoucherItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IssueVoucherID", iv.IssueVoucherID);
                cmd.Parameters.AddWithValue("@itemNumber", iv.itemNumber);
                cmd.Parameters.AddWithValue("@IssueQuantity", iv.IssueQuantity);
                cmd.Parameters.AddWithValue("@wareHouseID", iv.wareHouseID);


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetIsPrinted(IssueVoucher iv)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetIsPrinted", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IssueVoucherID", iv.IssueVoucherID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Contructor> GetContructor()
        {
            List<Contructor> obList = new List<Contructor>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetContructor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Contructor ob = new Contructor();
                    ob.contructorAddress = reader["contructorAddress"].ToString();
                    ob.contructorID = Convert.ToInt32(reader["contructorID"]);
                    ob.contructorName = reader["contructorName"].ToString();
                    ob.contructorPhone = reader["contructorPhone"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Contructor ob = new Contructor();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<IssueVoucher> GetIssueVoucher()
        {
            List<IssueVoucher> obList = new List<IssueVoucher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetSiliconIssueVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    IssueVoucher ob = new IssueVoucher();
                    ob.IssueQuantity = Convert.ToInt32(reader["IssueQuantity"]);
                    ob.IssueVoucherDate = reader["IssueVoucherDate"].ToString();
                    ob.IssueVoucherID = Convert.ToInt32(reader["IssueVoucherID"]);
                    ob.itemNumber = reader["itemNumber"].ToString();
                    ob.wareHouseID = Convert.ToInt32(reader["wareHouseID"]);
                    ob.workOrderNo = reader["workOrderNo"].ToString();
                    ob.Condition = reader["Condition"].ToString();
                    ob.contructorName = reader["contructorName"].ToString();
                    ob.description = reader["description"].ToString();
                    ob.IsPrinted = Convert.ToInt32(reader["IsPrinted"]);
                    ob.requisition = reader["requisition"].ToString();
                    ob.wareHouseName = reader["wareHouseName"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                IssueVoucher ob = new IssueVoucher();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Item> GetItem()
        {
            List<Item> obList = new List<Item>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetSiliconItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Item ob = new Item();
                    ob.itemID = Convert.ToInt32(reader["itemID"]);
                    ob.itemName = reader["itemName"].ToString();
                    ob.itemNumber = reader["itemNumber"].ToString();
                    ob.unit = reader["unit"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Item ob = new Item();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Supplier> GetSupplier()
        {
            List<Supplier> obList = new List<Supplier>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetSiliconSupplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Supplier ob = new Supplier();
                    ob.supplierAddress = reader["supplierAddress"].ToString();
                    ob.supplierID = Convert.ToInt32(reader["supplierID"]);
                    ob.supplierName = reader["supplierName"].ToString();
                    ob.supplierPhone = reader["supplierPhone"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Supplier ob = new Supplier();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Warehouse> GetWarehouse()
        {
            List<Warehouse> obList = new List<Warehouse>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetSiliconWarehouse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Warehouse ob = new Warehouse();
                    ob.wareHouseID = Convert.ToInt32(reader["wareHouseID"]);
                    ob.wareHouseName = reader["wareHouseName"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Warehouse ob = new Warehouse();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<WorkOrder> GetWorkOrder()
        {
            List<WorkOrder> obList = new List<WorkOrder>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetSiliconWorkOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    WorkOrder ob = new WorkOrder();
                    ob.contructorID = Convert.ToInt32(reader["contructorID"]);
                    ob.contructorName = reader["contructorName"].ToString();
                    ob.workOrderDate = reader["workOrderDate"].ToString();
                    ob.workOrderID = Convert.ToInt32(reader["workOrderID"]);
                    ob.workOrderNo = reader["workOrderNo"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                WorkOrder ob = new WorkOrder();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StockData> GetStockData()
        {
            List<StockData> obList = new List<StockData>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetAllStockData", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    StockData ob = new StockData();
                    ob.wareHouseID = Convert.ToInt32(reader["wareHouseID"]);
                    ob.itemID = Convert.ToInt32(reader["itemID"]);
                    ob.itemNO = reader["itemNO"].ToString();
                    ob.currentBalance = Convert.ToInt32(reader["currentBalance"]);
                    ob.unit = reader["unit"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                StockData ob = new StockData();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetRRVoucher(ReceiptVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetReceiptVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RRVoucherID", ob.RRVoucherID);
                cmd.Parameters.AddWithValue("@RRDate", ob.RRDate);
                cmd.Parameters.AddWithValue("@condition", ob.condition);
                cmd.Parameters.AddWithValue("@warehouse", ob.warehouse);
                cmd.Parameters.AddWithValue("@supplier", ob.supplier);
                cmd.Parameters.AddWithValue("@contructor", ob.contructor);
                cmd.Parameters.AddWithValue("@deliveredTo", ob.deliveredTo);
                cmd.Parameters.AddWithValue("@checkedby", ob.checkedby);
                cmd.Parameters.AddWithValue("@allocNumber", ob.allocNumber);
                cmd.Parameters.AddWithValue("@alolocDate", ob.alolocDate);
                cmd.Parameters.AddWithValue("@wordOrderNo", ob.wordOrderNo);
                cmd.Parameters.AddWithValue("@itemNumber", ob.itemNumber);
                cmd.Parameters.AddWithValue("@description", ob.description);
                cmd.Parameters.AddWithValue("@RCVQuantity", ob.RCVQuantity);
                cmd.Parameters.AddWithValue("@challan", ob.challan);
                cmd.Parameters.AddWithValue("@wareHouseID", ob.wareHouseID);


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ReceiptVoucher> GetRRVoucher()
        {
            List<ReceiptVoucher> obList = new List<ReceiptVoucher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.getReceiptVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    ReceiptVoucher ob = new ReceiptVoucher();
                    ob.RRVoucherID = Convert.ToInt32(reader["RRVoucherID"]);
                    ob.RRDate = reader["RRDate"].ToString();
                    ob.condition = reader["condition"].ToString();
                    ob.warehouse = reader["warehouse"].ToString(); ;
                    ob.supplier = reader["supplier"].ToString();
                    ob.contructor = reader["contructor"].ToString();
                    ob.deliveredTo = reader["deliveredTo"].ToString();
                    ob.checkedby = reader["checkedby"].ToString();
                    ob.allocNumber = Convert.ToInt32(reader["allocNumber"]);
                    ob.alolocDate = reader["alolocDate"].ToString();
                    ob.wordOrderNo = reader["wordOrderNo"].ToString();
                    ob.challan = reader["challan"].ToString(); 
                    ob.isPrinted = Convert.ToInt32(reader["isPrinted"]);
                    ob.itemNumber = reader["itemNumber"].ToString();
                    ob.description = reader["description"].ToString(); ;
                    ob.RCVQuantity = Convert.ToInt32(reader["RCVQuantity"]);
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                ReceiptVoucher ob = new ReceiptVoucher();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response DeleteRRVoucherItem(ReceiptVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.DeleteRRVoucherItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RRVoucherID", ob.RRVoucherID);
                cmd.Parameters.AddWithValue("@itemNumber", ob.itemNumber);
                cmd.Parameters.AddWithValue("@RCVQuantity", ob.RCVQuantity);
                cmd.Parameters.AddWithValue("@wareHouseID", ob.wareHouseID);


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setRRVooucherPrinted(ReceiptVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.setRRVooucherPrinted", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RRVoucherID", ob.RRVoucherID);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ReturnVoucher> GetReturnVoucher()
        {
            List<ReturnVoucher> obList = new List<ReturnVoucher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.getReturnVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    ReturnVoucher ob = new ReturnVoucher();
                    ob.retID = Convert.ToInt32(reader["retID"]);
                    ob.returnDate = reader["returnDate"].ToString();
                    ob.ret_type = reader["ret_type"].ToString();
                    ob.ret_warehouse = reader["ret_warehouse"].ToString();
                    ob.contructor = reader["contructor"].ToString();
                    ob.condition = reader["condition"].ToString();
                    ob.cause = reader["cause"].ToString();
                    ob.isPrinted = Convert.ToInt32(reader["isPrinted"]);
                    ob.wareHouseID = Convert.ToInt32(reader["wareHouseID"]);
                    ob.ItemNo = reader["ItemNo"].ToString();
                    ob.Description = reader["Description"].ToString();
                    ob.quentity = Convert.ToInt32(reader["quentity"]);
                    ob.workOrderNo = reader["workOrderNo"].ToString();
                    ob.Response = "OK";

                    obList.Add(ob);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                ReturnVoucher ob = new ReturnVoucher();
                ob.Response = ex.Message;
                obList.Add(ob);
            }
            return obList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setReturnlVoucher(ReturnVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetReturnVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@returnDate", ob.returnDate);
                cmd.Parameters.AddWithValue("@retID", ob.retID);
                cmd.Parameters.AddWithValue("@wareHouseID", ob.wareHouseID);
                cmd.Parameters.AddWithValue("@ret_warehouse", ob.ret_warehouse);
                cmd.Parameters.AddWithValue("@cause", ob.cause);
                cmd.Parameters.AddWithValue("@ret_type", ob.ret_type);
                cmd.Parameters.AddWithValue("@condition", ob.condition);
                cmd.Parameters.AddWithValue("@contructor", ob.contructor);
                cmd.Parameters.AddWithValue("@ItemNo", ob.ItemNo);
                cmd.Parameters.AddWithValue("@Description", ob.Description);
                cmd.Parameters.AddWithValue("@workOrderNo", ob.workOrderNo);
                cmd.Parameters.AddWithValue("@quentity", ob.quentity);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response RemoveReturnVoucher(ReturnVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.RemoveReturnVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@retID", ob.retID);
                cmd.Parameters.AddWithValue("@wareHouseID", ob.wareHouseID);
                cmd.Parameters.AddWithValue("@ItemNo", ob.ItemNo);
                cmd.Parameters.AddWithValue("@quentity", ob.quentity);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response PrintReturnVoucher(ReturnVoucher ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.printReturnVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@retID", ob.retID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<User> GetUserName()
        {
            List<User> userList = new List<User>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.getUserName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User us = new User();
                    us.userID = Convert.ToInt32(reader["userID"]);
                    us.userName = reader["userName"].ToString();
                    us.password = reader["password"].ToString();
                    us.userType = reader["userType"].ToString();
                    us.response ="ok";
                    userList.Add(us);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                User us = new User();
                us.response = ex.Message;
                userList.Add(us);
            }

            return userList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetStockData(StockData ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.Sillicon_SetStockData", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemID", ob.itemID);
                cmd.Parameters.AddWithValue("@itemNO", ob.itemNO);
                cmd.Parameters.AddWithValue("@currentBalance", ob.currentBalance);
                cmd.Parameters.AddWithValue("@unit", ob.unit);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetSupplier(Supplier ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.Sillicon_SetSupplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@supplierID", ob.supplierID);
                cmd.Parameters.AddWithValue("@supplierName", ob.supplierName);
                cmd.Parameters.AddWithValue("@supplierAddress", ob.supplierAddress);
                cmd.Parameters.AddWithValue("@supplierPhone", ob.supplierPhone);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetWareHouse(Warehouse ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.Sillicon_SetWareHouse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@wareHouseID", ob.wareHouseID);
                cmd.Parameters.AddWithValue("@wareHouseName", ob.wareHouseName);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetWorkOrder(WorkOrder ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.Sillicon_SetWorkOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@workOrderID", ob.workOrderID);
                cmd.Parameters.AddWithValue("@workOrderNo", ob.workOrderNo);
                cmd.Parameters.AddWithValue("@workOrderDate", ob.workOrderDate);
                cmd.Parameters.AddWithValue("@contructorID", ob.contructorID);
                cmd.Parameters.AddWithValue("@contructorName", ob.contructorName);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetContructor(Contructor ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.Sillicon_SetContructor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contructorID", ob.contructorID);
                cmd.Parameters.AddWithValue("@contructorName", ob.contructorName);
                cmd.Parameters.AddWithValue("@contructorAddress", ob.contructorAddress);
                cmd.Parameters.AddWithValue("@contructorPhone", ob.contructorPhone);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    response.Massage = "Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Unsuccesfull!";
                    response.Status = 1;
                }
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 0;
            }
            return response;
        }
    }
}