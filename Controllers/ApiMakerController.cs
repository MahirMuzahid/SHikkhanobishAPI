using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.ApiMaker;
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
    public class ApiMakerController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setAPiMaker(ApiMaker ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.setAPiMaker", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PrNumber", ob.PrNumber);
                cmd.Parameters.AddWithValue("@tableName", ob.tableName);
                cmd.Parameters.AddWithValue("@pr1n", ob.pr1n);
                cmd.Parameters.AddWithValue("@pr2n", ob.pr2n);
                cmd.Parameters.AddWithValue("@pr3n", ob.pr3n);
                cmd.Parameters.AddWithValue("@pr4n", ob.pr4n);
                cmd.Parameters.AddWithValue("@pr5n", ob.pr5n);
                cmd.Parameters.AddWithValue("@pr6n", ob.pr6n);
                cmd.Parameters.AddWithValue("@pr7n", ob.pr7n);
                cmd.Parameters.AddWithValue("@pr8n", ob.pr8n);
                cmd.Parameters.AddWithValue("@pr9n", ob.pr9n);
                cmd.Parameters.AddWithValue("@pr10n", ob.pr10n);
                cmd.Parameters.AddWithValue("@pr11n", ob.pr11n);
                cmd.Parameters.AddWithValue("@pr12n", ob.pr12n);
                cmd.Parameters.AddWithValue("@pr13n", ob.pr13n);
                cmd.Parameters.AddWithValue("@pr14n", ob.pr14n);
                cmd.Parameters.AddWithValue("@pr15n", ob.pr15n);
                cmd.Parameters.AddWithValue("@pr16n", ob.pr16n);
                cmd.Parameters.AddWithValue("@pr17n", ob.pr17n);
                cmd.Parameters.AddWithValue("@pr18n", ob.pr18n);
                cmd.Parameters.AddWithValue("@pr19n", ob.pr19n);
                cmd.Parameters.AddWithValue("@pr20n", ob.pr20n);
                cmd.Parameters.AddWithValue("@ID", ob.ID);


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
        public Response setAPiMakerInSingleColumn(ApiMaker ob)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.setAPiMakerInSingleColumn", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PrNumber", ob.PrNumber);
                cmd.Parameters.AddWithValue("@tableName", ob.tableName);
                cmd.Parameters.AddWithValue("@pr1n", ob.pr1n);
                cmd.Parameters.AddWithValue("@pr2n", ob.pr2n);
                cmd.Parameters.AddWithValue("@pr3n", ob.pr3n);
                cmd.Parameters.AddWithValue("@pr4n", ob.pr4n);
                cmd.Parameters.AddWithValue("@pr5n", ob.pr5n);
                cmd.Parameters.AddWithValue("@pr6n", ob.pr6n);
                cmd.Parameters.AddWithValue("@pr7n", ob.pr7n);
                cmd.Parameters.AddWithValue("@pr8n", ob.pr8n);
                cmd.Parameters.AddWithValue("@pr9n", ob.pr9n);
                cmd.Parameters.AddWithValue("@pr10n", ob.pr10n);
                cmd.Parameters.AddWithValue("@pr11n", ob.pr11n);
                cmd.Parameters.AddWithValue("@pr12n", ob.pr12n);
                cmd.Parameters.AddWithValue("@pr13n", ob.pr13n);
                cmd.Parameters.AddWithValue("@pr14n", ob.pr14n);
                cmd.Parameters.AddWithValue("@pr15n", ob.pr15n);
                cmd.Parameters.AddWithValue("@pr16n", ob.pr16n);
                cmd.Parameters.AddWithValue("@pr17n", ob.pr17n);
                cmd.Parameters.AddWithValue("@pr18n", ob.pr18n);
                cmd.Parameters.AddWithValue("@pr19n", ob.pr19n);
                cmd.Parameters.AddWithValue("@pr20n", ob.pr20n);
                cmd.Parameters.AddWithValue("@ID", ob.ID);


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
        public List<ApiMaker> getAPiMaker()
        {
            List<ApiMaker> obList = new List<ApiMaker>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.getAPiMaker", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ApiMaker ob = new ApiMaker();
                    ob.PrNumber = Convert.ToInt32(reader["PrNumber"]);
                    ob.tableName = reader["tableName"].ToString();
                    ob.pr1n = reader["pr1n"].ToString();
                    ob.pr2n = reader["pr2n"].ToString();
                    ob.pr3n = reader["pr3n"].ToString();
                    ob.pr4n = reader["pr4n"].ToString();
                    ob.pr5n = reader["pr5n"].ToString();
                    ob.pr6n = reader["pr6n"].ToString();
                    ob.pr7n = reader["pr7n"].ToString();
                    ob.pr8n = reader["pr8n"].ToString();
                    ob.pr9n = reader["pr9n"].ToString();
                    ob.pr10n = reader["pr10n"].ToString();
                    ob.pr11n = reader["pr11n"].ToString();
                    ob.pr12n = reader["pr12n"].ToString();
                    ob.pr13n = reader["pr13n"].ToString();
                    ob.pr14n = reader["pr14n"].ToString();
                    ob.pr15n = reader["pr15n"].ToString();
                    ob.pr16n = reader["pr16n"].ToString();
                    ob.pr17n = reader["pr17n"].ToString();
                    ob.pr18n = reader["pr18n"].ToString();
                    ob.pr19n = reader["pr19n"].ToString();
                    ob.pr20n = reader["pr20n"].ToString();
                    ob.ID = Convert.ToInt32(reader["ID"]);
                    obList.Add(ob);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ApiMaker ob = new ApiMaker();
                ob.Response = ex.Message;
                obList.Add(ob);
            }

            return obList;
        }
    }
}