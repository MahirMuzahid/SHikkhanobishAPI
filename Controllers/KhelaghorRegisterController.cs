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
    public class KhelaghorRegisterController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }
        #region KhelaGhorUser
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<KhelaGhorUser> getKhelaGhorUser()
        {
            List<KhelaGhorUser> objRList = new List<KhelaGhorUser>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getKhelaGhorUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhelaGhorUser objAdd = new KhelaGhorUser();
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.UserID = Convert.ToInt32(reader["UserID"]);
                    objAdd.TotalGame = Convert.ToInt32(reader["TotalGame"]);
                    objAdd.TotalWin = Convert.ToInt32(reader["TotalWin"]);
                    objAdd.TotalLoose = Convert.ToInt32(reader["TotalLoose"]);
                    objAdd.TotalDraw = Convert.ToInt32(reader["TotalDraw"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                KhelaGhorUser objAdd = new KhelaGhorUser();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public KhelaGhorUser getKhelaGhorUserWithID(KhelaGhorUser obj)
        {
            KhelaGhorUser objR = new KhelaGhorUser();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getKhelaGhorUserWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.UserID = Convert.ToInt32(reader["UserID"]);
                    objR.TotalGame = Convert.ToInt32(reader["TotalGame"]);
                    objR.TotalWin = Convert.ToInt32(reader["TotalWin"]);
                    objR.TotalLoose = Convert.ToInt32(reader["TotalLoose"]);
                    objR.TotalDraw = Convert.ToInt32(reader["TotalDraw"]);

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
        public Response setKhelaGhorUser(KhelaGhorUser obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setKhelaGhorUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@TotalGame", obj.TotalGame);
                cmd.Parameters.AddWithValue("@TotalWin", obj.TotalWin);
                cmd.Parameters.AddWithValue("@TotalLoose", obj.TotalLoose);
                cmd.Parameters.AddWithValue("@TotalDraw", obj.TotalDraw);
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
        public Response updateKhelaGhorUser(KhelaGhorUser obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateKhelaGhorUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@TotalGame", obj.TotalGame);
                cmd.Parameters.AddWithValue("@TotalWin", obj.TotalWin);
                cmd.Parameters.AddWithValue("@TotalLoose", obj.TotalLoose);
                cmd.Parameters.AddWithValue("@TotalDraw", obj.TotalDraw);
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
        #endregion
    }
}