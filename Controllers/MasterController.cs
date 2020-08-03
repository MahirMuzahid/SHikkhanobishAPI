using SHikkhanobishAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace SHikkhanobishAPI.Controllers
{
    public class MasterController : ApiController
    {
        private SqlConnection conn;

        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }
        //Tanvir:everything is Okay.......................................................{Post}.......................
        [AcceptVerbs("GET", "POST")]
        public Response RegisterStudent(Student student)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spSaveStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", student.UserName);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@InstitutionName", student.InstitutionName);
                cmd.Parameters.AddWithValue("@RechargedAmount", student.RechargedAmount);
                cmd.Parameters.AddWithValue("@IsPending", student.IsPending);
                cmd.Parameters.AddWithValue("@TotalTuitionTime", student.TotalTuitionTIme);
                cmd.Parameters.AddWithValue("@TotalTeacherCount", student.TotalTeacherCount);
                cmd.Parameters.AddWithValue("@AvarageRating", student.AvarageRating);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Registretion Succesfull!";
                    response.Status = 0;
                }
                else
                {
                    response.Massage = "Registretion Unsuccesfull!";
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
        //Tanvir:;everything is okay....................................................{get}.............................
        [AcceptVerbs("GET", "POST")]
        public Student GetInfoByLogin(Student studentm)
        {
            //Response response = new Response();
            Student student = new Student();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetInfoByUserNameAndPassword", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", studentm.UserName);
                cmd.Parameters.AddWithValue("@Password", studentm.Password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student.StundentID = Convert.ToInt32(reader["StudentID"]);
                    student.UserName = reader["UserName"].ToString();
                    student.Password = reader["Password"].ToString();
                    student.PhoneNumber = reader["PhoneNumber"].ToString();
                    student.Name = reader["Name"].ToString();
                    student.Age = Convert.ToInt32(reader["Age"]);
                    student.Class = reader["Class"].ToString();
                    student.InstitutionName = reader["InstitutionName"].ToString();
                    student.RechargedAmount = Convert.ToInt32(reader["RechargedAmount"]);
                    student.IsPending = Convert.ToInt32(reader["IsPending"]);
                    student.TotalTeacherCount = Convert.ToInt32(reader["TotalTeacherCount"]);
                    student.TotalTuitionTIme = Convert.ToInt32(reader["TotalTuitionTIme"]);
                    student.AvarageRating = Convert.ToInt32(reader["AvarageRatting"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                student.Response = ex.Message;
            }

            return student;
        }
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public Student SearchUserName(Student studentm)
        {
            Student student = new Student();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spSearchByUserName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", studentm.UserName);
                cmd.Parameters.AddWithValue("@PhoneNumber", studentm.PhoneNumber);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student.UserName = reader["UserName"].ToString();
                    student.PhoneNumber = reader["PhoneNumber"].ToString();
                    student.Response = "Matched";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                student.Response = ex.Message;
            }

            return student;
        }
        //Tanvir:Everything is Okay......................................................................{get}
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<TuitionHistoryStudent> GetTuitionHistoryStudent(TuitionHistoryStudent student)
        {
            List<TuitionHistoryStudent> tuitionHistoryList = new List<TuitionHistoryStudent>();
            try
            {
                int c = 0;
                Connection();
                SqlCommand cmd = new SqlCommand("[dbo].[spTuitionHistoryStudentNew]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("StudentID", student.StundentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TuitionHistoryStudent tuitionHistory = new TuitionHistoryStudent();
                    tuitionHistory.StundentID = Convert.ToInt32(reader["StudentID"]);
                    tuitionHistory.TutionTeacherID = Convert.ToInt32(reader["TutionTeacherID"]);
                    tuitionHistory.Class = reader["Class"].ToString();
                    tuitionHistory.Subject = reader["Subject"].ToString();
                    tuitionHistory.Time = reader["Time"].ToString();
                    tuitionHistory.Date = reader["Date"].ToString();
                    tuitionHistory.Ratting = Convert.ToInt32(reader["Rating"]);
                    tuitionHistoryList.Add(tuitionHistory);
                    c++;
                }

                TuitionHistoryStudent tuitionHistoryy = new TuitionHistoryStudent();
                tuitionHistoryy.Response = "" + c;
                tuitionHistoryList.Add(tuitionHistoryy);
                conn.Close();
            }
            catch (Exception ex)
            {
                TuitionHistoryStudent T = new TuitionHistoryStudent();
                T.Response = ex.Message;
                tuitionHistoryList.Add(T);
            }
            return tuitionHistoryList;
        }

        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<TuitionHistoryTeacher> GetTuitionHistoryTeacher(TuitionHistoryTeacher teacher)
        {
            List<TuitionHistoryTeacher> tuitionHistoryList = new List<TuitionHistoryTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("[dbo].[spTuitionHistoryTeacher]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TeacherID", teacher.TeacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TuitionHistoryTeacher tuitionHistory = new TuitionHistoryTeacher();
                    tuitionHistory.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                    tuitionHistory.TuitionStundentID = Convert.ToInt32(reader["TuitionStudentID"]);
                    tuitionHistory.Class = reader["Class"].ToString();
                    tuitionHistory.Subject = reader["Subject"].ToString();
                    tuitionHistory.Time = reader["Time"].ToString();
                    tuitionHistory.Date = reader["Date"].ToString();
                    tuitionHistory.Ratting = Convert.ToInt32(reader["Ratting"]);
                    tuitionHistoryList.Add(tuitionHistory);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TuitionHistoryTeacher T = new TuitionHistoryTeacher();
                T.Response = ex.Message;
                tuitionHistoryList.Add(T);
            }
            return tuitionHistoryList;
        }

        [AcceptVerbs("GET", "POST")]
        public Response RegisterTeacher(AllSubAndTeacherReagister registerTeacher)
        {
            Response response = new Response();

            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spInsertSubject", conn);

                cmd.Parameters.AddWithValue("@TeacherID", registerTeacher.TeacherID);
                cmd.Parameters.AddWithValue("@LSBAN01", registerTeacher.LSBAN01);
                cmd.Parameters.AddWithValue("@LSBAN02", registerTeacher.LSBAN02);
                cmd.Parameters.AddWithValue("@LSENG01", registerTeacher.LSENG01);
                cmd.Parameters.AddWithValue("@LSENG02", registerTeacher.LSENG02);
                cmd.Parameters.AddWithValue("@LSICT", registerTeacher.LSICT);
                cmd.Parameters.AddWithValue("@LSBGS", registerTeacher.LSBGS);
                cmd.Parameters.AddWithValue("@LSAGR", registerTeacher.LSAGR);
                cmd.Parameters.AddWithValue("@LSCRE", registerTeacher.LSCRE);
                cmd.Parameters.AddWithValue("@LSGSC", registerTeacher.LSGSC);
                cmd.Parameters.AddWithValue("@LSMATH", registerTeacher.LSMATH);
                cmd.Parameters.AddWithValue("@SBAN01", registerTeacher.SBAN01);
                cmd.Parameters.AddWithValue("@SBAN02", registerTeacher.SBAN02);
                cmd.Parameters.AddWithValue("@SENG01", registerTeacher.SENG01);
                cmd.Parameters.AddWithValue("@SENG02", registerTeacher.SENG02);
                cmd.Parameters.AddWithValue("@SGMATH", registerTeacher.SGMATH);
                cmd.Parameters.AddWithValue("@SREL", registerTeacher.SREL);
                cmd.Parameters.AddWithValue("@SICT", registerTeacher.SICT);
                cmd.Parameters.AddWithValue("@SGSC", registerTeacher.SGSC);
                cmd.Parameters.AddWithValue("@SPHY", registerTeacher.SPHY);
                cmd.Parameters.AddWithValue("@SCHE", registerTeacher.SCHE);
                cmd.Parameters.AddWithValue("@SBIO", registerTeacher.SBIO);
                cmd.Parameters.AddWithValue("@SHMATH", registerTeacher.SHMATH);
                cmd.Parameters.AddWithValue("@SECO", registerTeacher.SECO);
                cmd.Parameters.AddWithValue("@SACC", registerTeacher.SACC);
                cmd.Parameters.AddWithValue("@SFIN", registerTeacher.SFIN);
                cmd.Parameters.AddWithValue("@SAGR", registerTeacher.SAGR);
                cmd.Parameters.AddWithValue("@SHOM", registerTeacher.SHOM);
                cmd.Parameters.AddWithValue("@SBENT", registerTeacher.SBENT);
                cmd.Parameters.AddWithValue("@SCRE", registerTeacher.SCRE);
                cmd.Parameters.AddWithValue("@SBGS", registerTeacher.SBGS);
                cmd.Parameters.AddWithValue("@SGEO", registerTeacher.SGEO);
                cmd.Parameters.AddWithValue("@SPEDU", registerTeacher.SPEDU);
                cmd.Parameters.AddWithValue("@HSBAN01", registerTeacher.HSBAN01);
                cmd.Parameters.AddWithValue("@HSBAN02", registerTeacher.HSBAN02);
                cmd.Parameters.AddWithValue("@HSENG01", registerTeacher.HSENG01);
                cmd.Parameters.AddWithValue("@HSENG02", registerTeacher.HSENG02);
                cmd.Parameters.AddWithValue("@HSPHY01", registerTeacher.HSPHY01);
                cmd.Parameters.AddWithValue("@HSPHY02", registerTeacher.HSPHY02);
                cmd.Parameters.AddWithValue("@HSCHE01", registerTeacher.HSCHE01);
                cmd.Parameters.AddWithValue("@HSCHE02", registerTeacher.HSCHE02);
                cmd.Parameters.AddWithValue("@HSBIO01", registerTeacher.HSBIO01);
                cmd.Parameters.AddWithValue("@HSBIO02", registerTeacher.HSBIO02);
                cmd.Parameters.AddWithValue("@HSMATH01", registerTeacher.HSMATH01);
                cmd.Parameters.AddWithValue("@HSMATH02", registerTeacher.HSMATH02);
                cmd.Parameters.AddWithValue("@HSICT", registerTeacher.HSICT);
                cmd.Parameters.AddWithValue("@HSSTAT", registerTeacher.HSSTAT);
                cmd.Parameters.AddWithValue("@HSLOG", registerTeacher.HSLOG);
                cmd.Parameters.AddWithValue("@HSFOOD", registerTeacher.HSFOOD);
                cmd.Parameters.AddWithValue("@HSFIN", registerTeacher.HSFIN);
                cmd.Parameters.AddWithValue("@HSACC", registerTeacher.HSACC);
                cmd.Parameters.AddWithValue("@HSECO", registerTeacher.HSECO);
                cmd.Parameters.AddWithValue("@StudentID", registerTeacher.StudentID);
                cmd.Parameters.AddWithValue("@InstitutionID", registerTeacher.InstitutionID);
                cmd.Parameters.AddWithValue("@TeacherName", registerTeacher.TeacherName);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Teacher Registration Success";
                    response.Status = 0;
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
        //Tanvir:Everythiing is Okay...................................................get Request
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<TeacherID> TeacherIDListFromSubject(Subject subject)
        {
            List<TeacherID> teacherIDList = new List<TeacherID>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spGetTeacherIDbySubject", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Subject", subject.subject);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherID T_ID = new TeacherID();
                    T_ID.teacherID = Convert.ToInt32(reader["TeacherID"]);

                    if (subject.subject == "LSBAN01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSBAN01"]);
                    }
                    else if (subject.subject == "LSBAN02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSBAN02"]);
                    }
                    else if (subject.subject == "LSENG01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSENG01"]);
                    }
                    else if (subject.subject == "LSENG02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSENG02"]);
                    }
                    else if (subject.subject == "LSICT")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSICT"]);
                    }
                    else if (subject.subject == "LSAGR")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSAGR"]);
                    }
                    else if (subject.subject == "LSGSC")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSGSC"]);
                    }
                    else if (subject.subject == "LSMATH")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSMATH"]);
                    }
                    else if (subject.subject == "SBAN01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SBAN01"]);
                    }
                    else if (subject.subject == "SBAN02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SBAN02"]);
                    }
                    else if (subject.subject == "SENG01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SENG01"]);
                    }
                    else if (subject.subject == "LSBAN02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSBAN02"]);
                    }
                    else if (subject.subject == "SENG02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SENG02"]);
                    }
                    else if (subject.subject == "SGMATH")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SGMATH"]);
                    }
                    else if (subject.subject == "SICT")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SICT"]);
                    }
                    else if (subject.subject == "SGSC")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SGSC"]);
                    }
                    else if (subject.subject == "SPHY")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SPHY"]);
                    }
                    else if (subject.subject == "SCHE")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SCHE"]);
                    }
                    else if (subject.subject == "SBIO")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SBIO"]);
                    }
                    else if (subject.subject == "SHMATH")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SHMATH"]);
                    }
                    else if (subject.subject == "SECO")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SECO"]);
                    }
                    else if (subject.subject == "SACC")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SACC"]);
                    }
                    else if (subject.subject == "SFIN")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SFIN"]);
                    }
                    else if (subject.subject == "SAGR")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SAGR"]);
                    }
                    else if (subject.subject == "SHOM")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SHOM"]);
                    }
                    else if (subject.subject == "SBENT")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SBENT"]);
                    }
                    else if (subject.subject == "SCRE")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SCRE"]);
                    }
                    else if (subject.subject == "SBGS")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SBGS"]);
                    }
                    else if (subject.subject == "SGEO")
                    {
                        T_ID.Point = Convert.ToInt32(reader["SGEO"]);
                    }
                    else if (subject.subject == "HSBAN01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSBAN01"]);
                    }
                    else if (subject.subject == "HSBAN02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSBAN02"]);
                    }
                    else if (subject.subject == "HSENG01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSENG01"]);
                    }
                    else if (subject.subject == "HSENG02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSENG02"]);
                    }
                    else if (subject.subject == "HSPHY01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSPHY01"]);
                    }
                    else if (subject.subject == "HSPHY02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSPHY02"]);
                    }
                    else if (subject.subject == "HSCHE01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSCHE01"]);
                    }
                    else if (subject.subject == "HSCHE02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSCHE02"]);
                    }
                    else if (subject.subject == "HSBIO01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSBIO01"]);
                    }
                    else if (subject.subject == "HSBIO02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSBIO02"]);
                    }
                    else if (subject.subject == "HSMATH01")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSMATH01"]);
                    }
                    else if (subject.subject == "HSMATH02")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSMATH02"]);
                    }
                    else if (subject.subject == "HSICT")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSICT"]);
                    }
                    else if (subject.subject == "HSSTAT")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSSTAT"]);
                    }
                    else if (subject.subject == "HSLOG")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSLOG"]);
                    }
                    else if (subject.subject == "HSFIN")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSFIN"]);
                    }
                    else if (subject.subject == "HSACC")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSACC"]);
                    }
                    else if (subject.subject == "HSECO")
                    {
                        T_ID.Point = Convert.ToInt32(reader["HSECO"]);
                    }
                    else if (subject.subject == "LSCRE")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSCRE"]);
                    }
                    else if (subject.subject == "LSBGS")
                    {
                        T_ID.Point = Convert.ToInt32(reader["LSBGS"]);
                    }
                    T_ID.response = "OK";
                    teacherIDList.Add(T_ID);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                TeacherID T_ID = new TeacherID();
                T_ID.response = ex.Message;
                teacherIDList.Add(T_ID);
            }
            return teacherIDList;
        }
        /*get response...but,get 25 values.response =student id..................{get}
         
            [
    {
        "TeacherID": 0,
        "InstituitionID": null,
        "StudentID": 0,
        "IsActive": 0,
        "IsOnTuition": 0,
        "Five_Star": 0,
        "Four_Star": 0,
        "Three_Star": 0,
        "Two_Star": 0,
        "One_Star": 0,
        "Total_Min": 0,
        "Number_Of_Tution": 0,
        "Tuition_Point": 0,
        "Teacher_Rank": null,
        "TeacherName": null,
        "UserName": null,
        "Password": null,
        "PhoneNumber": null,
        "Name": null,
        "Age": 0,
        "Class": null,
        "InstitutionName": null,
        "RechargedAmount": 0,
        "response": "StudentID"
    }
] 
             
             
             
             
             */
        [AcceptVerbs("GET")]
        public IEnumerable<Teacher> GetTeacher()
        {
            List<Teacher> teacherList = new List<Teacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spGetAllTeacher", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher T = new Teacher();
                    T.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                    T.InstituitionID = reader["InstituitionID"].ToString();
                    T.IsActive = Convert.ToInt32(reader["IsActive"]);
                    T.IsOnTuition = Convert.ToInt32(reader["IsOnTuition"]);
                    T.StudentID = Convert.ToInt32(reader["StudentID"]);
                    T.Five_Star = Convert.ToInt32(reader["Five_Star"]);
                    T.Four_Star = Convert.ToInt32(reader["Four_Star"]);
                    T.Three_Star = Convert.ToInt32(reader["Three_Star"]);
                    T.Two_Star = Convert.ToInt32(reader["Two_Star"]);
                    T.One_Star = Convert.ToInt32(reader["One_Star"]);
                    T.Total_Min = Convert.ToInt32(reader["Total_Min"]);
                    T.Number_Of_Tution = Convert.ToInt32(reader["Number_Of_Tution"]);
                    T.Tuition_Point = Convert.ToInt32(reader["Tuition_Point"]);
                    T.Teacher_Rank = reader["Teacher_Rank"].ToString();
                    T.TeacherName = reader["TeacherName"].ToString();
                    T.response = "OK";
                    teacherList.Add(T);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Teacher T = new Teacher();
                T.response = ex.Message;
                teacherList.Add(T);
            }
            return teacherList;
        }
        //PROBLEM....."Massage": "Incorrect syntax near '101'.",
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public Response UpdateInfo(InfoForUpdate info)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("[dbo].[spUpdateTuitionInfoForTeacherAndStudent]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", info.TeacherID);
                cmd.Parameters.AddWithValue("@IsActive", info.IsActive);
                cmd.Parameters.AddWithValue("@IsOnTuition", info.IsOnTuition);
                cmd.Parameters.AddWithValue("@StudentID", info.StudentID);
                cmd.Parameters.AddWithValue("@Rating", info.Rating);
                cmd.Parameters.AddWithValue("@InAppMin", info.InAppMin);
                cmd.Parameters.AddWithValue("@Tuition_Point", info.Tuition_Point);
                cmd.Parameters.AddWithValue("@Teacher_Rank", info.Teacher_Rank);
                cmd.Parameters.AddWithValue("@Date", info.Date);
                cmd.Parameters.AddWithValue("@Subject", info.Subject);
                cmd.Parameters.AddWithValue("@SubjectName", info.SubjectName);
                cmd.Parameters.AddWithValue("@Class", info.Class);
                cmd.Parameters.AddWithValue("@IsPending", info.IsPenidng);
                cmd.Parameters.AddWithValue("@Teacher_Name", info.Teacher_Name);
                cmd.Parameters.AddWithValue("@Student_Name", info.Student_Name);
                cmd.Parameters.AddWithValue("@Cost", info.Cost);

                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Info Update Success";
                    response.Status = 0;
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
        //problem...... "Massage": "There is a problem",
        //Mahir:: Works Perfectly   

        [AcceptVerbs("GET", "POST")]
        public Response ChangeStateofIsActive(ActiveState As)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("[dbo].[spTurnOnOrOffIsActive]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", As.TeacherID);
                cmd.Parameters.AddWithValue("@state", As.State);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = " Active State change!";
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
        //Tanvir::problem occur here.doing post request.......
        //Mahir:: Works Perfectly   

        [AcceptVerbs("GET", "POST")]
        public Response ChangeStateofIsOnTuition(ActiveState As)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("[dbo].[spTurnOnOrOffIsOnTuition]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", As.TeacherID);
                cmd.Parameters.AddWithValue("@state", As.State);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Tuition State change!";
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
        //Tanvir:Work perfectly.......................post
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public Response ReportTeacher(Report r)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.ReportTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", r.StudentID);
                cmd.Parameters.AddWithValue("@TeacherID ", r.TeacherID);
                cmd.Parameters.AddWithValue("@ReportType", r.ReportType);
                cmd.Parameters.AddWithValue("@ReportText", r.ReportText);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Report Submitted";
                    response.Status = 0;
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
        //Tanvir::problem ........get request.....
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public PremiumStudents GetPremiumStudent(PremiumStudents ps)
        {
            PremiumStudents PS = new PremiumStudents();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetPremiumStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", ps.StudentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PS.StudentID = Convert.ToInt32(reader["StudentID"]);
                    PS.response = "Ok";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                PS.response = ex.Message;
            }
            return PS;
        }
        //Tanvir:eitar table e value insert kora nai................
        //Mahir:: Debug This
        //Tanvir::done
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public VoucherAndOffer GetVoucherInfo(VoucherAndOffer vs)
        {
            VoucherAndOffer VS = new VoucherAndOffer();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetVoucherInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", vs.Code);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VS.StudentID = Convert.ToInt32(reader["StudentID"]);
                    VS.Type = reader["Type"].ToString();
                    VS.Amount = Convert.ToInt32(reader["Amount"]);
                    VS.IsPremium = Convert.ToInt32(reader["IsPremium"]);
                    VS.Response = "OK";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                VS.Response = ex.Message;
            }
            return VS;
        }
        //work perfectly...........................................................post.........
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public Response RegisterParent(Parents parents)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.RegisterParrent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParentsName", parents.ParentName);
                cmd.Parameters.AddWithValue("@ParentsMobileNumber ", parents.ParentMobileNumber);
                cmd.Parameters.AddWithValue("@StudnetID", parents.StudentID);
                cmd.Parameters.AddWithValue("@Password", parents.Password);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Report Submitted";
                    response.Status = 0;
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
        //error in code
        //Mahir::  Debug This
        //Tanvir:;done...............................
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public Response SetPremiumStudent(PremiumStudents ps)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetPremiumStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", ps.StudentID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Report Submitted";
                    response.Status = 0;
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
        //tanvir::work perfectly.........................get 
        [AcceptVerbs("GET", "POST")]
        public Student RecoverInfoStudent(Student s)
        {
            Student student = new Student();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("RecoverInfoStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phonenumber", s.PhoneNumber);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student.UserName = reader["UserName"].ToString();
                    student.Password = reader["Password"].ToString();
                    student.Response = "ok";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                student.Response = ex.Message;
            }
            return student;
        }
        //Phone number is null in Database
        //Mahir:: Works Perfectly   
        [AcceptVerbs("GET", "POST")]
        public Teacher RecoverInfoTeacher(Teacher t)
        {
            Teacher teacher = new Teacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("RecoverInfoTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phonenumber", t.PhoneNumber);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    teacher.UserName = reader["UserName"].ToString();
                    teacher.Password = reader["Password"].ToString();
                    teacher.response = "ok";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                teacher.response = ex.Message;
            }
            return teacher;
        }

        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public Response CreateTeacherVideoApiColumn(TeacherVideoCallApi tva)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.CreateTeacherVideoApiColumn", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", tva.TeacherID);
                cmd.Parameters.AddWithValue("@APIKey", tva.APIKey);
                cmd.Parameters.AddWithValue("@SessionID", tva.SessionID);
                cmd.Parameters.AddWithValue("@Token", tva.Token);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Session Created";
                    response.Status = 0;
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
        //Mahir:: Works Perfectly            
        [AcceptVerbs("GET", "POST")]
        public Response SetTeacherVideoCallAPi(TeacherVideoCallApi tva)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetTeacherVideoCallAPi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", tva.TeacherID);
                cmd.Parameters.AddWithValue("@APIKey", tva.APIKey);
                cmd.Parameters.AddWithValue("@SessionID", tva.SessionID);
                cmd.Parameters.AddWithValue("@Token", tva.Token);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "Problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Session Set";
                    response.Status = 0;
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
        //Tanvir::Database Table is Empty............................get request
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public TeacherVideoCallApi GetTeacherVideoCallAPi(TeacherVideoCallApi tva)
        {
            TeacherVideoCallApi TVA = new TeacherVideoCallApi();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GerTeacherVideoCallAPi", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", tva.TeacherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TVA.APIKey = Convert.ToInt32(reader["APIKey"]);
                    TVA.SessionID = reader["SessionID"].ToString();
                    TVA.Token = reader["Token"].ToString();
                    TVA.Response = "ok";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                TVA.Response = ex.Message;
            }
            return TVA;
        }
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public Teacher GetInfoByLoginTeacher(Teacher teacher)
        {
            Teacher T = new Teacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetInfoByUserNameAndPasswordTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", teacher.UserName);
                cmd.Parameters.AddWithValue("@Password", teacher.Password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    T.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                    T.InstituitionID = reader["InstituitionID"].ToString();
                    T.IsActive = Convert.ToInt32(reader["IsActive"]);
                    T.IsOnTuition = Convert.ToInt32(reader["IsOnTuition"]);
                    T.Five_Star = Convert.ToInt32(reader["Five_Star"]);
                    T.Four_Star = Convert.ToInt32(reader["Four_Star"]);
                    T.Three_Star = Convert.ToInt32(reader["Three_Star"]);
                    T.Two_Star = Convert.ToInt32(reader["Two_Star"]);
                    T.One_Star = Convert.ToInt32(reader["One_Star"]);
                    T.Total_Min = Convert.ToInt32(reader["Total_Min"]);
                    T.Number_Of_Tution = Convert.ToInt32(reader["Number_Of_Tution"]);
                    T.Tuition_Point = Convert.ToInt32(reader["Tuition_Point"]);
                    T.Teacher_Rank = reader["Teacher_Rank"].ToString();
                    T.TeacherName = reader["TeacherName"].ToString();
                    T.UserName = reader["UserName"].ToString();
                    T.Password = reader["Password"].ToString();
                    T.PhoneNumber = reader["PhoneNumber"].ToString();
                    T.Name = reader["Name"].ToString();
                    T.Age = Convert.ToInt32(reader["Age"]);
                    T.Class = reader["Class"].ToString();
                    T.InstitutionName = reader["InstitutionName"].ToString();
                    T.RechargedAmount = Convert.ToInt32(reader["RechargedAmount"]);
                    T.response = "OK";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                T.response = ex.Message;
            }

            return T;
        }
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public Response SetnewPasswordOrUsername(ResetInfo ri)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetnewPasswordOrUsername", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", ri.Username);
                cmd.Parameters.AddWithValue("@IsTeacherorStudent", ri.IsTeacherorStudent);
                cmd.Parameters.AddWithValue("@IsPasswordOrUsername", ri.IsPasswordOrUsername);
                cmd.Parameters.AddWithValue("@NewpassOrUsername", ri.NewpassOrUsername);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "Reset Done";
                    response.Status = 0;
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
        //Mahir:: Works Perfectly
        [AcceptVerbs("GET", "POST")]
        public IsPending GetPending(IsPending ip)
        {
            IsPending IP = new IsPending();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetIsPending", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID ", ip.StudentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    IP.TeacherName = reader["TeacherName"].ToString();
                    IP.TeacherID = Convert.ToInt32(reader["TeacherID"]);
                    IP.Class = reader["Class"].ToString();
                    IP.Subject = reader["Subject"].ToString();
                    IP.Time = Convert.ToInt32(reader["Time"]);
                    IP.Cost = Convert.ToInt32(reader["Cost"]);
                    IP.Response = "ok";
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                IP.Response = ex.Message;
            }
            return IP;
        }
        //tanvir::work perfectly......post request....
        [AcceptVerbs("GET", "POST")]
        public Response SetPending(IsPending ip)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetIsPending", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", ip.StudentID);
                cmd.Parameters.AddWithValue("@TeacherName", ip.TeacherName);
                cmd.Parameters.AddWithValue("@TeacherID", ip.TeacherID);
                cmd.Parameters.AddWithValue("@Class", ip.Class);
                cmd.Parameters.AddWithValue("@Subject", ip.Subject);
                cmd.Parameters.AddWithValue("@Time", ip.Time);
                cmd.Parameters.AddWithValue("@Cost", ip.Cost);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "set pending dome";
                    response.Status = 0;
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
        public TeacherInfo GetTeacherInfo(TeacherInfo ti)
        {
            TeacherInfo TI = new TeacherInfo();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.GetTeacherInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", ti.Username);
                cmd.Parameters.AddWithValue("@PhoneNumber", ti.PhoneNumber);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TI.Name = reader["Name"].ToString();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                TI.response = ex.Message;
            }
            return TI;
        }
        [AcceptVerbs("GET", "POST")]
        public Response SetTeacherInfo(TeacherInfo ti)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkhanobish.SetTeacherInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", ti.Name);
                cmd.Parameters.AddWithValue("@Username", ti.Username);//
                cmd.Parameters.AddWithValue("@Password", ti.Password);//

                cmd.Parameters.AddWithValue("@Age", ti.Age);           //

                cmd.Parameters.AddWithValue("@Institution", ti.Institution);
                cmd.Parameters.AddWithValue("@PhoneNumber", ti.PhoneNumber);
                cmd.Parameters.AddWithValue("@Mail", ti.Mail);

                cmd.Parameters.AddWithValue("@SubjectInfo", ti.SubjectInfo);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i <= 0)
                {
                    response.Massage = "There is a problem";
                    response.Status = 1;
                }
                else
                {
                    response.Massage = "successfully executed";
                    response.Status = 0;
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











    }
}