﻿using Flurl.Http;
using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.Shikkhanobish;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace SHikkhanobishAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShikkhanobishTeacherController : ApiController
    {
        private SqlConnection conn;
        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }
        public ShikkhanobishTeacherController()
        {

        }
        public float CalculateRatting(float fs, float fos, float th, float to, float on)
        {
            float toalRating = 0 ;

            float totalSum = fs * 5 + fos * 4 + th * 3 + to * 2 + on;

            toalRating = totalSum / (fs + fos + th + to + on);

            return toalRating;
        }

        public const int PremiumStudentBuyingAmount = 99;
        public const int maxNumberOfFavouriteTeacherForNonPremimumStudent = 1;

        #region Teacher
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Teacher> getAllTeacher(Teacher obj)
        {
            List<Teacher> objRList = new List<Teacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher objR = new Teacher();
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

                    objRList.Add(objR);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Teacher objR = new Teacher();
                objR.Response = ex.Message;

                objRList.Add(objR);
            }
            return objRList;
        }
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
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Teacher checkRegphonenumber(Teacher obj)
        {
            Teacher objR = new Teacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("checkRegphonenumber", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    obj.Response = "ok";
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
        public Response activeTeacher(Teacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("activeTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@activeStatus", obj.activeStatus);
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                cmd.Parameters.AddWithValue("@activeTime", date);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;

        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response SetTeacher(setTeacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setTeacher", conn);
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@sub1", obj.sub1);
                cmd.Parameters.AddWithValue("@sub2", obj.sub2);
                cmd.Parameters.AddWithValue("@sub3", obj.sub3);
                cmd.Parameters.AddWithValue("@sub4", obj.sub4);
                cmd.Parameters.AddWithValue("@sub5", obj.sub5);
                cmd.Parameters.AddWithValue("@sub6", obj.sub6);
                cmd.Parameters.AddWithValue("@sub7", obj.sub7);
                cmd.Parameters.AddWithValue("@sub8", obj.sub8);
                cmd.Parameters.AddWithValue("@sub9", obj.sub9);
                cmd.Parameters.AddWithValue("@activeTime", date);
                cmd.Parameters.AddWithValue("@sub10", obj.sub10);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;

        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response changeTeacherInf0(ChangeTeacherInfo obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("changeTeacherInf0", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@info", obj.info);
                cmd.Parameters.AddWithValue("@index", obj.index);
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;

        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response updateTeacherInfo(Teacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateTeacherInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                cmd.Parameters.AddWithValue("@selectionStatus", obj.selectionStatus);
                cmd.Parameters.AddWithValue("@monetizetionStatus", obj.monetizetionStatus);
                cmd.Parameters.AddWithValue("@totalMinuite", obj.totalMinuite);
                cmd.Parameters.AddWithValue("@favTeacherCount", obj.favTeacherCount);
                cmd.Parameters.AddWithValue("@reportCount", obj.reportCount);
                cmd.Parameters.AddWithValue("@totalTuition", obj.totalTuition);
                cmd.Parameters.AddWithValue("@fiveStar", obj.fiveStar);
                cmd.Parameters.AddWithValue("@fourStar", obj.fourStar);
                cmd.Parameters.AddWithValue("@threeStar", obj.threeStar);
                cmd.Parameters.AddWithValue("@twoStar", obj.twoStar);
                cmd.Parameters.AddWithValue("@oneStar", obj.oneStar);
                cmd.Parameters.AddWithValue("@amount", obj.amount);
                cmd.Parameters.AddWithValue("@activeStatus", obj.activeStatus);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;

        }
        public Response selectTeacher(Teacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("selectTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;

        }
        #endregion

        #region Tuitio History 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentTuitionHistory> getAllTuitionHistory(StudentTuitionHistory obj)
        {
            List<StudentTuitionHistory> objRList = new List<StudentTuitionHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllTuitionHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentTuitionHistory objR = new StudentTuitionHistory();
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.tuitionID = reader["tuitionID"].ToString();
                    objR.time = reader["time"].ToString();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.cost = Convert.ToInt32(reader["cost"]);
                    objR.ratting = Convert.ToDouble(reader["ratting"]);
                    objR.firstChoiceID = reader["firstChoiceID"].ToString();
                    objR.secondChoiceID = reader["secondChoiceID"].ToString();
                    objR.thirdChoiceID = reader["thirdChoiceID"].ToString();
                    objR.forthChoiceID = reader["forthChoiceID"].ToString();
                    objR.studentName = reader["studentName"].ToString();
                    objR.teacherName = reader["teacherName"].ToString();
                    objR.date = reader["date"].ToString();
                    objR.firstChoiceName = reader["firstChoiceName"].ToString();
                    objR.secondChoiceName = reader["secondChoiceName"].ToString();
                    objR.thirdChoiceName = reader["thirdChoiceName"].ToString();
                    objR.forthChoiceName = reader["forthChoiceName"].ToString();
                    objR.teacherEarn = Convert.ToDouble(reader["teacherEarn"]);
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                StudentTuitionHistory objR = new StudentTuitionHistory();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentTuitionHistory> getTeacherTuitionHistoryWithID(StudentTuitionHistory obj)
        {
            List<StudentTuitionHistory> objRList = new List<StudentTuitionHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTeacherTuitionHistoryWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentTuitionHistory objR = new StudentTuitionHistory();
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.tuitionID = reader["tuitionID"].ToString();
                    objR.time = reader["time"].ToString();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.cost = Convert.ToInt32(reader["cost"]);
                    objR.ratting = Convert.ToDouble(reader["ratting"]);
                    objR.firstChoiceID = reader["firstChoiceID"].ToString();
                    objR.secondChoiceID = reader["secondChoiceID"].ToString();
                    objR.thirdChoiceID = reader["thirdChoiceID"].ToString();
                    objR.forthChoiceID = reader["forthChoiceID"].ToString();
                    objR.studentName = reader["studentName"].ToString();
                    objR.teacherName = reader["teacherName"].ToString();
                    objR.date = reader["date"].ToString();
                    objR.firstChoiceName = reader["firstChoiceName"].ToString();
                    objR.secondChoiceName = reader["secondChoiceName"].ToString();
                    objR.thirdChoiceName = reader["thirdChoiceName"].ToString();
                    objR.forthChoiceName = reader["forthChoiceName"].ToString();
                    objR.teacherEarn = Convert.ToDouble(reader["teacherEarn"]);
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                StudentTuitionHistory objR = new StudentTuitionHistory();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        #endregion

        #region Tuitio & Withdraw History 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response updateTeacherWithdraw(TeacherWithdrawHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateTeacherWithdraw", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@withdrawID", obj.withdrawID);
                cmd.Parameters.AddWithValue("@status", obj.status);

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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setTeacherWithdrawHistory(TeacherWithdrawHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setTeacherWithdrawHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@withdrawID", obj.withdrawID);
                cmd.Parameters.AddWithValue("@date", obj.date);
                cmd.Parameters.AddWithValue("@trxID", obj.trxID);
                cmd.Parameters.AddWithValue("@amountTaka", obj.amountTaka);
                cmd.Parameters.AddWithValue("@phoneNumber", obj.phoneNumber);
                cmd.Parameters.AddWithValue("@medium", obj.medium);
                cmd.Parameters.AddWithValue("@status", obj.status);
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<TeacherWithdrawHistory> getAllTeacherWithdrawHistor(TeacherWithdrawHistory obj)
        {
            List<TeacherWithdrawHistory> objRList = new List<TeacherWithdrawHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllTeacherWithdrawHistor", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherWithdrawHistory objR = new TeacherWithdrawHistory();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.trxID = reader["trxID"].ToString();
                    objR.date = reader["date"].ToString();
                    objR.withdrawID = Convert.ToInt32(reader["withdrawID"]);
                    objR.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objR.medium = reader["medium"].ToString(); ;
                    objR.phoneNumber = reader["phoneNumber"].ToString();
                    objR.status = Convert.ToInt32(reader["status"]);
                    objR.response = "ok";
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TeacherWithdrawHistory objR = new TeacherWithdrawHistory();
                objR.response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<TeacherWithdrawHistory> getTeacherWithdrawHistoryWithID(TeacherWithdrawHistory obj)
        {
            List<TeacherWithdrawHistory> objRList = new List<TeacherWithdrawHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTeacherWithdrawHistoryWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherWithdrawHistory objR = new TeacherWithdrawHistory();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.trxID = reader["trxID"].ToString();
                    objR.date = reader["date"].ToString();
                    objR.withdrawID = Convert.ToInt32(reader["withdrawID"]);
                    objR.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objR.medium = reader["medium"].ToString(); ;
                    objR.phoneNumber = reader["phoneNumber"].ToString();
                    objR.status = Convert.ToInt32(reader["status"]);
                    objR.response = "ok";
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TeacherWithdrawHistory objR = new TeacherWithdrawHistory();
                objR.response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        #endregion

        #region CourseList
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<CousrList> getAllCousrList(CousrList obj)
        {
            List<CousrList> objRList = new List<CousrList>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllCousrList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CousrList objR = new CousrList();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.sub1 = Convert.ToInt32(reader["sub1"]);
                    objR.sub2 = Convert.ToInt32(reader["sub2"]);
                    objR.sub3 = Convert.ToInt32(reader["sub3"]);
                    objR.sub4 = Convert.ToInt32(reader["sub4"]);
                    objR.sub5 = Convert.ToInt32(reader["sub5"]);
                    objR.sub6 = Convert.ToInt32(reader["sub6"]);
                    objR.sub7 = Convert.ToInt32(reader["sub7"]);
                    objR.sub8 = Convert.ToInt32(reader["sub8"]);
                    objR.sub9 = Convert.ToInt32(reader["sub9"]);
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
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                CousrList objR = new CousrList();
                objR.Response = ex.Message;
                 objRList.Add(objR);
            }
            return objRList;
        }
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
                    objR.sub7 = Convert.ToInt32(reader["sub7"]);
                    objR.sub8 = Convert.ToInt32(reader["sub8"]);
                    objR.sub9 = Convert.ToInt32(reader["sub9"]);
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
                cmd.Parameters.AddWithValue("@sub7", obj.sub7);
                cmd.Parameters.AddWithValue("@sub8", obj.sub8);
                cmd.Parameters.AddWithValue("@sub9", obj.sub9);
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
        public Response updateCourseList(CousrList obj)
        {
            Response response = new Response();
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                Connection();
                SqlCommand cmd = new SqlCommand("updateCourseList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@sub1", obj.sub1);
                cmd.Parameters.AddWithValue("@sub2", obj.sub2);
                cmd.Parameters.AddWithValue("@sub3", obj.sub3);
                cmd.Parameters.AddWithValue("@sub4", obj.sub4);
                cmd.Parameters.AddWithValue("@sub5", obj.sub5);
                cmd.Parameters.AddWithValue("@sub6", obj.sub6);
                cmd.Parameters.AddWithValue("@sub7", obj.sub7);
                cmd.Parameters.AddWithValue("@sub8", obj.sub8);
                cmd.Parameters.AddWithValue("@sub9", obj.sub9);
                cmd.Parameters.AddWithValue("@sub10", obj.sub10);
                cmd.Parameters.AddWithValue("@activeTime", date);

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

        #region Favourite Teacher
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<List<favouriteTeacher>> getFavouriteTeacherwithStudentIDForPopUp(favouriteTeacher obj)
        {
            List<favouriteTeacher> filteredTeacher = new List<favouriteTeacher>();
            List<favouriteTeacher> objRList = new List<favouriteTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFavouriteTeacherwithStudentID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    favouriteTeacher objR = new favouriteTeacher();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objRList.Add(objR);
                }
                conn.Close();
                int filteredTeacherCount = 0;
                for (int i = 0; i < objRList.Count; i++)
                {
                    Teacher thisTeacher = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/getTeacherWithID".PostUrlEncodedAsync(new { teacherID = objRList[i].teacherID })
          .ReceiveJson<Teacher>();
                    if(thisTeacher.activeStatus == 1)
                    {
                        CousrList thiscrsList = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/getCousrListWithID".PostUrlEncodedAsync(new { teacherID = objRList[i].teacherID })
           .ReceiveJson<CousrList>();
                        bool found = false;
                        if (thiscrsList.sub1 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub2 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub3 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub4 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub5 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub6 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub7 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub8 == obj.subjectID)
                        {
                            found = true;
                        }
                        else if (thiscrsList.sub9 == obj.subjectID)
                        {
                            found = true;
                        }
                        if (found == true)
                        {
                            filteredTeacher.Add(objRList[i]);
                            filteredTeacher[filteredTeacherCount].teacherName = thisTeacher.name;
                            filteredTeacher[filteredTeacherCount].teacherTotalTuition = thisTeacher.totalTuition;
                            if (thisTeacher.totalTuition == 0)
                            {
                                filteredTeacher[filteredTeacherCount].teacherRatting = 0;
                            }
                            else
                            {
                                filteredTeacher[filteredTeacherCount].teacherRatting = CalculateRatting(thisTeacher.fiveStar, thisTeacher.fourStar, thisTeacher.threeStar, thisTeacher.twoStar, thisTeacher.oneStar);
                            }
                            filteredTeacherCount++;
                        }
                    }
                                     
                }              
            }
            catch (Exception ex)
            {
                favouriteTeacher objR = new favouriteTeacher();
                objR.Response = ex.Message;
                filteredTeacher.Add(objR);
            }
            return filteredTeacher;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<List<favouriteTeacher>> getFavouriteTeacherwithStudentID(favouriteTeacher obj)
        {
            List<favouriteTeacher> objRList = new List<favouriteTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFavouriteTeacherwithStudentID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    favouriteTeacher objR = new favouriteTeacher();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objRList.Add(objR);
                }
                conn.Close();
                for (int i = 0; i < objRList.Count; i++)
                {
                    Teacher thisTeacher = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/getTeacherWithID".PostUrlEncodedAsync(new { teacherID = objRList[i].teacherID })
          .ReceiveJson<Teacher>();
                    objRList[i].teacherName = thisTeacher.name;
                    objRList[i].teacherTotalTuition = thisTeacher.totalTuition;
                    if (thisTeacher.totalTuition == 0)
                    {
                        objRList[i].teacherRatting = 0;
                    }
                    else
                    {
                        objRList[i].teacherRatting = CalculateRatting(thisTeacher.fiveStar, thisTeacher.fourStar, thisTeacher.threeStar, thisTeacher.twoStar, thisTeacher.oneStar);
                    }
                }
            }
            catch (Exception ex)
            {
                favouriteTeacher objR = new favouriteTeacher();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response removeFavTeacherWithTeacherID(favouriteTeacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("removeFavTeacherWithTeacherID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
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
        public List<favouriteTeacher> getAllfavouriteTeacher(favouriteTeacher obj)
        {
            List<favouriteTeacher> objRList = new List<favouriteTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllfavouriteTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    favouriteTeacher objR = new favouriteTeacher();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.studentName = reader["studentName"].ToString();
                    objR.teacherName = reader["teacherName"].ToString();
                    objR.teacherTotalTuition = Convert.ToInt32(reader["teacherTotalTuition"]);
                    objR.teacherRatting = Convert.ToDouble(reader["teacherRatting"]);
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                favouriteTeacher objR = new favouriteTeacher();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<favouriteTeacher> getFavouriteTeacherwithTeacherID(favouriteTeacher obj)
        {
            List<favouriteTeacher> objRList = new List<favouriteTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFavouriteTeacherwithTeacherID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    favouriteTeacher objR = new favouriteTeacher();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                favouriteTeacher objR = new favouriteTeacher();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response addasFavouriteTeacher(favouriteTeacher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("addasFavouriteTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
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
        public List<favouriteTeacher> getFavTeacherByTeacherID(favouriteTeacher obj)
        {
            List<favouriteTeacher> objRList = new List<favouriteTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFavTeacherByTeacherID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    favouriteTeacher objR = new favouriteTeacher();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                favouriteTeacher objR = new favouriteTeacher();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        #endregion

        #region Premium Teacher 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public PremiumStudent getAllPremiumStudent(PremiumStudent obj)
        {
            PremiumStudent objR = new PremiumStudent();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllPremiumStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.studentID = Convert.ToInt32(reader["studentID"]);


                }
                objR.buyingAmount = PremiumStudentBuyingAmount;
                if (objR.studentID == 0)
                {
                    objR.maxNumberofFavouriteTeacher = maxNumberOfFavouriteTeacherForNonPremimumStudent + "";
                }
                else
                {
                    objR.maxNumberofFavouriteTeacher = "Unlimited";
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
        public PremiumStudent getPremiumStudentWithID(PremiumStudent obj)
        {
            PremiumStudent objR = new PremiumStudent();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getPremiumStudentWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                   
                   
                }
                objR.buyingAmount = PremiumStudentBuyingAmount;
                if (objR.studentID == 0)
                {
                    objR.maxNumberofFavouriteTeacher = maxNumberOfFavouriteTeacherForNonPremimumStudent+"";
                }
                else
                {
                    objR.maxNumberofFavouriteTeacher = "Unlimited";
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
        public Response makePremiumStudent(PremiumStudent obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("makePremiumStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
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

        #region Report Teacher 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setReport(ReportTeacherTable obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setReport", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@reportID", obj.reportID);
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@reportIndex", obj.reportIndex);
                cmd.Parameters.AddWithValue("@description", obj.description);
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
                conn.Close();
            }
            catch (Exception ex)
            {
                response.Massage = ex.Message;
                response.Status = 1;
            }
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ReportTeacherTable> getAllReportTeacherTable(ReportTeacherTable obj)
        {
            List<ReportTeacherTable> objRList = new List<ReportTeacherTable>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAllReportTeacherTable", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReportTeacherTable objR = new ReportTeacherTable();
                    objR.reportID = Convert.ToInt32(reader["reportID"]);
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.reportIndex = Convert.ToInt32(reader["reportIndex"]);
                    objR.description = reader["description"].ToString();
                    obj.Response = "ok";
                    objRList.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ReportTeacherTable objR = new ReportTeacherTable();
                objR.Response = ex.Message;
                objRList.Add(obj);
            }
            return objRList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ReportTeacherTable> getReportWithTeacherID(ReportTeacherTable obj)
        {
            List<ReportTeacherTable> objRList = new List<ReportTeacherTable>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getReportWithTeacherID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReportTeacherTable objR = new ReportTeacherTable();
                    objR.reportID = Convert.ToInt32(reader["reportID"]);
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.reportIndex = Convert.ToInt32(reader["reportIndex"]);
                    objR.description = reader["description"].ToString();
                    obj.Response = "ok";
                    objRList.Add(obj);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ReportTeacherTable objR = new ReportTeacherTable();
                objR.Response = ex.Message;
                objRList.Add(obj);
            }
            return objRList;
        }
        #endregion

        #region Take Test 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<TeacherTest> GetTeacherTest()
        {
            List<TeacherTest> objRList = new List<TeacherTest>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetTeacherTest", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherTest objR = new TeacherTest();
                    objR.questionID = Convert.ToInt32(reader["questionID"]);
                    objR.question = reader["question"].ToString();
                    objR.opOne = reader["opOne"].ToString();
                    objR.opTwo = reader["opTwo"].ToString();
                    objR.opThree = reader["opThree"].ToString();
                    objR.opFour = reader["opFour"].ToString();
                    objR.rightAns = Convert.ToInt32(reader["rightAns"]);
                    objR.Response = "ok";
                    objRList.Add(objR);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TeacherTest objR = new TeacherTest();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }
        #endregion

        #region AppVersion


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public AppVersion getAppVersion()
        {
            AppVersion objAdd = new AppVersion();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getAppVersion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objAdd.studentAtVersion = Convert.ToInt32(reader["studentAtVersion"]);
                    objAdd.teacherAtVersion = Convert.ToInt32(reader["teacherAtVersion"]);

                    objAdd.Response = "Ok";

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                objAdd.Response = ex.Message;
            }
            return objAdd;
        }
        //......................................//

        // Test: 
        // URL:https:
        /* Parameter
        {
            
        }

        */

        //......................................//

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setAppVesrion(AppVersion obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setAppVesrion", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentAtVersion", obj.studentAtVersion);
                cmd.Parameters.AddWithValue("@teacherAtVersion", obj.teacherAtVersion);

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

        #region TeacherActivityStatus

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<Response> setTeacherActivityStatus(TeacherActivityStatus obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setTeacherActivityStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@activityStatus", obj.activityStatus);

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
            await Task.Delay(1000);
            var res = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/DeleteActivityStatus".PostUrlEncodedAsync(new { teacherID = obj.teacherID }).ReceiveJson<Response>();
            return response;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<TeacherActivityStatus> getTeacherActivityStatus()
        {
            List<TeacherActivityStatus> objRList = new List<TeacherActivityStatus>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTeacherActivityStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherActivityStatus objAdd = new TeacherActivityStatus();
                    objAdd.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objAdd.activityStatus = Convert.ToInt32(reader["activityStatus"]);

                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TeacherActivityStatus objAdd = new TeacherActivityStatus();
                var Response = ex.InnerException;
                objRList.Add(objAdd);
            }
            return objRList;

        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response DeleteActivityStatus(TeacherActivityStatus obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("DeleteActivityStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);

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