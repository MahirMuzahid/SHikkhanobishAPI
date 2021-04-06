using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.Shikkhanobish;
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
    public class ShikkhanobishLoginController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }

        #region ShikkhanobishUser
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ShikkhanobishUser> getShikkhanobishUser()
        {
            List<ShikkhanobishUser> objRList = new List<ShikkhanobishUser>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getShikkhanobishUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShikkhanobishUser objAdd = new ShikkhanobishUser();
                    objAdd.UserID = Convert.ToInt32(reader["UserID"]);
                    objAdd.Name = reader["Name"].ToString();
                    objAdd.PhoneNumber = reader["PhoneNumber"].ToString();
                    objAdd.Address = reader["Address"].ToString();
                    objAdd.City = reader["City"].ToString();
                    objAdd.Password = reader["Password"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ShikkhanobishUser objAdd = new ShikkhanobishUser();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public ShikkhanobishUser getShikkhanobishUserWithID(ShikkhanobishUser obj)
        {
            ShikkhanobishUser objR = new ShikkhanobishUser();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getShikkhanobishUserWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.UserID = Convert.ToInt32(reader["UserID"]);
                    objR.Name = reader["Name"].ToString();
                    objR.PhoneNumber = reader["PhoneNumber"].ToString();
                    objR.Address = reader["Address"].ToString();
                    objR.City = reader["City"].ToString();
                    objR.Password = reader["Password"].ToString();

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                objR.Response = ex.Message;
            }
            return objR;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setShikkhanobishUser(ShikkhanobishUser obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setShikkhanobishUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
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
        public Response updateShikkhanobishUser(ShikkhanobishUser obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateShikkhanobishUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
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
        public ShikkhanobishUser LoginInShikkhanboish(ShikkhanobishUser obj)
        {
            ShikkhanobishUser objR = new ShikkhanobishUser();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("LoginInShikkhanboish", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.UserID = Convert.ToInt32(reader["UserID"]);
                    objR.Name = reader["Name"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                objR.Response = ex.Message;
            }
            return objR;
        }
        #endregion
    }
}