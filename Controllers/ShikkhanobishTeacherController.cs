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
    public class ShikkhanobishTeacherController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }

        #region Teacher
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Teacher getTeacherWithID(Teacher obj)
        {
            Teacher objR = new Teacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTeacherWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.name = reader["name"].ToString();
                    objR.password = reader["password"].ToString();
                    objR.phonenumber = reader["phonenumber"].ToString();
                    objR.selectionStatus = Convert.ToInt32(reader["selectionStatus"]);
                    objR.monetizetionStatus = Convert.ToInt32(reader["monetizetionStatus"]);
                    objR.activeStatus = Convert.ToInt32(reader["activeStatus"]);
                    objR.totalMinuite = Convert.ToInt32(reader["totalMinuite"]);
                    objR.favTeacherCount = Convert.ToInt32(reader["favTeacherCount"]);
                    objR.reportCount = Convert.ToInt32(reader["reportCount"]);
                    objR.totalTuition = Convert.ToInt32(reader["totalTuition"]);
                    objR.fiveStar = Convert.ToInt32(reader["fiveStar"]);
                    objR.fourStar = Convert.ToInt32(reader["fourStar"]);
                    objR.threeStar = Convert.ToInt32(reader["threeStar"]);
                    objR.twoStar = Convert.ToInt32(reader["twoStar"]);
                    objR.oneStar = Convert.ToInt32(reader["oneStar"]);
                    objR.amount = Convert.ToDouble(reader["amount"]);

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
        public Teacher loginTeacher(Teacher obj)
        {
            Teacher objR = new Teacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("loginTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.name = reader["name"].ToString();
                    objR.password = reader["password"].ToString();
                    objR.phonenumber = reader["phonenumber"].ToString();
                    objR.selectionStatus = Convert.ToInt32(reader["selectionStatus"]);
                    objR.monetizetionStatus = Convert.ToInt32(reader["monetizetionStatus"]);
                    objR.activeStatus = Convert.ToInt32(reader["activeStatus"]);
                    objR.totalMinuite = Convert.ToInt32(reader["totalMinuite"]);
                    objR.favTeacherCount = Convert.ToInt32(reader["favTeacherCount"]);
                    objR.reportCount = Convert.ToInt32(reader["reportCount"]);
                    objR.totalTuition = Convert.ToInt32(reader["totalTuition"]);
                    objR.fiveStar = Convert.ToInt32(reader["fiveStar"]);
                    objR.fourStar = Convert.ToInt32(reader["fourStar"]);
                    objR.threeStar = Convert.ToInt32(reader["threeStar"]);
                    objR.twoStar = Convert.ToInt32(reader["twoStar"]);
                    objR.oneStar = Convert.ToInt32(reader["oneStar"]);
                    objR.amount = Convert.ToDouble(reader["amount"]);

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

        #region CourseList
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public CousrList getCousrListWithID(CousrList obj)
        {
            CousrList objR = new CousrList();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCousrListWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.sub1 = Convert.ToInt32(reader["sub1"]);
                    objR.sub2 = Convert.ToInt32(reader["sub2"]);
                    objR.sub3 = Convert.ToInt32(reader["sub3"]);
                    objR.sub4 = Convert.ToInt32(reader["sub4"]);
                    objR.sub5 = Convert.ToInt32(reader["sub5"]);
                    objR.sub6 = Convert.ToInt32(reader["sub6"]);
                    objR.crs1 = Convert.ToInt32(reader["crs1"]);
                    objR.crs2 = Convert.ToInt32(reader["crs2"]);
                    objR.crs3 = Convert.ToInt32(reader["crs3"]);
                    objR.crs4 = Convert.ToInt32(reader["crs4"]);
                    objR.crs5 = Convert.ToInt32(reader["crs5"]);
                    objR.crs6 = Convert.ToInt32(reader["crs6"]);
                    objR.crs7 = Convert.ToInt32(reader["crs7"]);
                    objR.crs8 = Convert.ToInt32(reader["crs8"]);
                    objR.crs9 = Convert.ToInt32(reader["crs9"]);
                    objR.crs10 = Convert.ToInt32(reader["crs10"]);

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
        public List<SubList> GetSubListInfo(CousrList obj)
        {
            List<SubList> objRList = new List<SubList>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetSubListInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sub1", obj.sub1);
                cmd.Parameters.AddWithValue("@sub2", obj.sub2);
                cmd.Parameters.AddWithValue("@sub3", obj.sub3);
                cmd.Parameters.AddWithValue("@sub4", obj.sub4);
                cmd.Parameters.AddWithValue("@sub5", obj.sub5);
                cmd.Parameters.AddWithValue("@sub6", obj.sub6);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubList objR = new SubList();
                    objR.name = reader["name"].ToString();
                    objR.Response = "ok";
                    objRList.Add(objR);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                SubList objR = new SubList();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<SubList> getCrsListInfo(CousrList obj)
        {
            List<SubList> objRList = new List<SubList>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCrsListInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@crs1", obj.crs1);
                cmd.Parameters.AddWithValue("@crs2", obj.crs2);
                cmd.Parameters.AddWithValue("@crs3", obj.crs3);
                cmd.Parameters.AddWithValue("@crs4", obj.crs4);
                cmd.Parameters.AddWithValue("@crs5", obj.crs5);
                cmd.Parameters.AddWithValue("@crs6", obj.crs6);
                cmd.Parameters.AddWithValue("@crs7", obj.crs7);
                cmd.Parameters.AddWithValue("@crs8", obj.crs8);
                cmd.Parameters.AddWithValue("@crs9", obj.crs9);
                cmd.Parameters.AddWithValue("@crs10", obj.crs10);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubList objR = new SubList();
                    objR.name = reader["name"].ToString();
                    objR.Response = "ok";
                    objRList.Add(objR);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                SubList objR = new SubList();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }

        #endregion
    }
}