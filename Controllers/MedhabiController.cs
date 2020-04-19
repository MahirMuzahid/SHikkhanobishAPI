using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.Medhabi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SHikkhanobishAPI.Controllers
{
    public class MedhabiController : ApiController
    {
        private SqlConnection conn;

        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["medhabiConnection"].ToString();
            conn = new SqlConnection(conString);
        }

        [AcceptVerbs("GET", "POST")]
        public Response RegisterStudent(medhabiStudent student)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.setStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mail", student.mail);
                cmd.Parameters.AddWithValue("@password", student.password);
                cmd.Parameters.AddWithValue("@phonenumber", student.phonenumber);
                cmd.Parameters.AddWithValue("@name", student.name);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Complete";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;
        }
        [AcceptVerbs("GET", "POST")]
        public Response SubmitQuestion(Questions q)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.submiteqs", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@question_code", q.question_code);
                cmd.Parameters.AddWithValue("@question", q.question);
                cmd.Parameters.AddWithValue("@first_choice", q.first_choice);
                cmd.Parameters.AddWithValue("@second_choice", q.second_choice);
                cmd.Parameters.AddWithValue("@third_choice", q.third_choice);
                cmd.Parameters.AddWithValue("@forth_choice", q.forth_choice);
                cmd.Parameters.AddWithValue("@right_answer", q.right_answer);
                cmd.Parameters.AddWithValue("@name", q.name);


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Submitted";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;
        }

        [AcceptVerbs("GET", "POST")]
        public Questions GetQuestionNumber ()
        {
            Questions number =  new Questions();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getQuestionAmount", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    number.amount = Convert.ToInt32(reader["number"]);
                    number.response = "Ok";
                    number.stetus = 0;
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                number.response = ex.Message;
                number.stetus = 1;
            }

            return number;
        }


    }
}
