using Flurl.Http;
using SHikkhanobishAPI.Models;
using SHikkhanobishAPI.Models.Shikkhanobish;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace SHikkhanobishAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShikkhanobishLoginController : ApiController
    {
        private SqlConnection conn;
        public const int SchoolCost = 3;
        public const int CollegeCost = 4;
        public const double processignCostPercent = 0.2;

        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ToString();
            conn = new SqlConnection(conString);
        }
        public float CalculateRatting(float fs, float fos, float th, float to, float on)
        {
            float toalRating;

            float totalSum = fs * 5 + fos * 4 + th * 3 + to * 2 + on;
            float totalNum = fs + fos + th + to + on;
            if(totalNum == 0)
            {
                toalRating = 0;
            }
            else
            {
                toalRating = totalSum / (fs + fos + th + to + on);
            }
           

            return toalRating;
        }
        #region Send Msg
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<SendSms> SendSmsAsync(SendSms obj)
        {
            importantKeyAndnfoTable allKey = new importantKeyAndnfoTable();
            SendSms res = new SendSms();
            try
            {

                string apiKey = "b0dOQWlNd0xrTnpIanlNSE9kRnM=";
                string uri = "http://services.smsq.global/sms/api?action=send-sms&api_key="+ apiKey+"&to=" + obj.number+ "&from=8804445620753&sms=" + obj.msg;
                //string ull = "http://services.smsq.global/sms/api?action=send-sms&api_key="+ apiKey +"&to= " + obj.number + "&from=8804445620753&sms=" + obj.msg;
                res = await uri.GetJsonAsync<SendSms>();
                if(res.code == "ok")
                {
                    res.respose = "ok";
                }
                else
                {
                    res.respose = allKey.smsApiKey;
                }
            }
            catch
            {                
                res.code = "not ok";
            }
            return res;
        }

        #endregion

        #region Student
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Student> getStudent()
        {
            List<Student> objRList = new List<Student>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student objAdd = new Student();
                    objAdd.studentID = Convert.ToInt32(reader["studentID"]);
                    objAdd.phonenumber = reader["phonenumber"].ToString();
                    objAdd.password = reader["password"].ToString();
                    objAdd.totalSpent = Convert.ToInt32(reader["totalSpent"]);
                    objAdd.totalTuitionTime = Convert.ToInt32(reader["totalTuitionTime"]);
                    objAdd.coin = Convert.ToInt32(reader["coin"]);
                    objAdd.freemin = Convert.ToInt32(reader["freemin"]);
                    objAdd.city = reader["city"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.institutionName = reader["institutionName"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Student objAdd = new Student();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Student LoginStudent(Student obj)
        {
            Student objR = new Student();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("LoginStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                cmd.Parameters.AddWithValue("@password", obj.password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.phonenumber = reader["phonenumber"].ToString();
                    objR.password = reader["password"].ToString();
                    objR.totalSpent = Convert.ToInt32(reader["totalSpent"]);
                    objR.totalTuitionTime = Convert.ToInt32(reader["totalTuitionTime"]);
                    objR.coin = Convert.ToInt32(reader["coin"]);
                    objR.freemin = Convert.ToInt32(reader["freemin"]);
                    objR.city = reader["city"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.institutionName = reader["institutionName"].ToString();

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
        public Student getStudentWithID(Student obj)
        {
            Student objR = new Student();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudentWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.phonenumber = reader["phonenumber"].ToString();
                    objR.password = reader["password"].ToString();
                    objR.totalSpent = Convert.ToInt32(reader["totalSpent"]);
                    objR.totalTuitionTime = Convert.ToInt32(reader["totalTuitionTime"]);
                    objR.coin = Convert.ToInt32(reader["coin"]);
                    objR.freemin = Convert.ToInt32(reader["freemin"]);
                    objR.city = reader["city"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.institutionName = reader["institutionName"].ToString();

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
        public Response setStudent(Student obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@totalSpent", obj.totalSpent);
                cmd.Parameters.AddWithValue("@totalTuitionTime", obj.totalTuitionTime);
                cmd.Parameters.AddWithValue("@coin", obj.coin);
                cmd.Parameters.AddWithValue("@freemin", obj.freemin);
                cmd.Parameters.AddWithValue("@city", obj.city);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@institutionName", obj.institutionName);
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
        public Response updateStudent(Student obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@phonenumber", obj.phonenumber);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@totalSpent", obj.totalSpent);
                cmd.Parameters.AddWithValue("@totalTuitionTime", obj.totalTuitionTime);
                cmd.Parameters.AddWithValue("@coin", obj.coin);
                cmd.Parameters.AddWithValue("@freemin", obj.freemin);
                cmd.Parameters.AddWithValue("@city", obj.city);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@institutionName", obj.institutionName);
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


        #region Chapter
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Chapter> getChapter()
        {
            List<Chapter> objRList = new List<Chapter>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getChapter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Chapter objAdd = new Chapter();
                    objAdd.subjectID = Convert.ToInt32(reader["subjectID"]);
                    objAdd.chapterID = Convert.ToInt32(reader["chapterID"]);
                    objAdd.classID = Convert.ToInt32(reader["classID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.name = reader["name"].ToString();
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Chapter objAdd = new Chapter();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Chapter getChapterWithID(Chapter obj)
        {
            Chapter objR = new Chapter();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getChapterWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subjectID", obj.subjectID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.subjectID = Convert.ToInt32(reader["subjectID"]);
                    objR.chapterID = Convert.ToInt32(reader["chapterID"]);
                    objR.classID = Convert.ToInt32(reader["classID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo"]);

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
        public Response setChapter(Chapter obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setChapter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subjectID", obj.subjectID);
                cmd.Parameters.AddWithValue("@chapterID", obj.chapterID);
                cmd.Parameters.AddWithValue("@classID", obj.classID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", 0);
                cmd.Parameters.AddWithValue("@avgRatting", 0);
                cmd.Parameters.AddWithValue("@indexNo", 0);
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
        public Response updateChapter(Chapter obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateChapter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subjectID", obj.subjectID);
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


        #region ClassInfo
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ClassInfo> getClassInfo()
        {
            List<ClassInfo> objRList = new List<ClassInfo>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getClassInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassInfo objAdd = new ClassInfo();
                    objAdd.institutionID = Convert.ToInt32(reader["institutionID"]);
                    objAdd.classID = Convert.ToInt32(reader["classID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ClassInfo objAdd = new ClassInfo();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public ClassInfo getClassInfoWithID(ClassInfo obj)
        {
            ClassInfo objR = new ClassInfo();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getClassInfoWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.institutionID = Convert.ToInt32(reader["institutionID"]);
                    objR.classID = Convert.ToInt32(reader["classID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo "]);

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
        public Response setClassInfo(ClassInfo obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setClassInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
                cmd.Parameters.AddWithValue("@classID", obj.classID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", 0);
                cmd.Parameters.AddWithValue("@avgRatting", 0);
                cmd.Parameters.AddWithValue("@indexNo ", 0);
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
        public Response updateClassInfo(ClassInfo obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateClassInfo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
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


        #region Course
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Course> getCourse()
        {
            List<Course> objRList = new List<Course>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course objAdd = new Course();
                    objAdd.degreeID = Convert.ToInt32(reader["degreeID"]);
                    objAdd.courseID = Convert.ToInt32(reader["courseID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Course objAdd = new Course();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Course getCourseWithID(Course obj)
        {
            Course objR = new Course();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCourseWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@degreeID", obj.degreeID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.degreeID = Convert.ToInt32(reader["degreeID"]);
                    objR.courseID = Convert.ToInt32(reader["courseID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo "]);

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
        public Response setCourse(Course obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@degreeID", obj.degreeID);
                cmd.Parameters.AddWithValue("@courseID", obj.courseID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", obj.tuitionRequest);
                cmd.Parameters.AddWithValue("@avgRatting", obj.avgRatting);
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
                cmd.Parameters.AddWithValue("@indexNo ", obj.indexNo);
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
        public Response updateCourse(Course obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@degreeID", obj.degreeID);
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


        #region Degree
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Degree> getDegree()
        {
            List<Degree> objRList = new List<Degree>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getDegree", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Degree objAdd = new Degree();
                    objAdd.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objAdd.degreeID = Convert.ToInt32(reader["degreeID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Degree objAdd = new Degree();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Degree getDegreeWithID(Degree obj)
        {
            Degree objR = new Degree();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getDegreeWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objR.degreeID = Convert.ToInt32(reader["degreeID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo "]);

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
        public Response setDegree(Degree obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setDegree", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
                cmd.Parameters.AddWithValue("@degreeID", obj.degreeID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", obj.tuitionRequest);
                cmd.Parameters.AddWithValue("@avgRatting", obj.avgRatting);
                cmd.Parameters.AddWithValue("@indexNo ", obj.indexNo);
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
        public Response updateDegree(Degree obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateDegree", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
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


        #region Institution
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Institution> getInstitution()
        {
            List<Institution> objRList = new List<Institution>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getInstitution", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Institution objAdd = new Institution();
                    objAdd.institutionID = Convert.ToInt32(reader["institutionID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Institution objAdd = new Institution();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Institution getInstitutionWithID(Institution obj)
        {
            Institution objR = new Institution();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getInstitutionWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.institutionID = Convert.ToInt32(reader["institutionID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.avgRatting = Convert.ToInt32(reader["avgRatting"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo "]);

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
        public Response setInstitution(Institution obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setInstitution", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", 0);
                cmd.Parameters.AddWithValue("@avgRatting", 0);
                cmd.Parameters.AddWithValue("@indexNo ", 0);
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
        public Response updateInstitution(Institution obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateInstitution", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@institutionID", obj.institutionID);
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


        #region SelectPattern
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<SelectPattern> getSelectPattern()
        {
            List<SelectPattern> objRList = new List<SelectPattern>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSelectPattern", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SelectPattern objAdd = new SelectPattern();
                    objAdd.slPatternID = Convert.ToInt32(reader["slPatternID"]);
                    objAdd.firstIndex = Convert.ToInt32(reader["firstIndex"]);
                    objAdd.secondIndex = Convert.ToInt32(reader["secondIndex"]);
                    objAdd.thirdindex = Convert.ToInt32(reader["thirdindex"]);
                    objAdd.forthindex = Convert.ToInt32(reader["forthindex"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                SelectPattern objAdd = new SelectPattern();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public SelectPattern getSelectPatternWithID(SelectPattern obj)
        {
            SelectPattern objR = new SelectPattern();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSelectPatternWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@slPatternID", obj.slPatternID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.slPatternID = Convert.ToInt32(reader["slPatternID"]);
                    objR.firstIndex = Convert.ToInt32(reader["firstIndex"]);
                    objR.secondIndex = Convert.ToInt32(reader["secondIndex"]);
                    objR.thirdindex = Convert.ToInt32(reader["thirdindex"]);
                    objR.forthindex = Convert.ToInt32(reader["forthindex"]);

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
        public Response setSelectPattern(SelectPattern obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setSelectPattern", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@slPatternID", obj.slPatternID);
                cmd.Parameters.AddWithValue("@firstIndex", obj.firstIndex);
                cmd.Parameters.AddWithValue("@secondIndex", obj.secondIndex);
                cmd.Parameters.AddWithValue("@thirdindex", obj.thirdindex);
                cmd.Parameters.AddWithValue("@forthindex", obj.forthindex);
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
        public Response updateSelectPattern(SelectPattern obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateSelectPattern", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@slPatternID", obj.slPatternID);
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


        #region StudentPaymentHistory
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentPaymentHistory> getStudentPaymentHistory()
        {
            List<StudentPaymentHistory> objRList = new List<StudentPaymentHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudentPaymentHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentPaymentHistory objAdd = new StudentPaymentHistory();
                    objAdd.studentID = Convert.ToInt32(reader["studentID"]);
                    objAdd.paymentID = reader["paymentID"].ToString();
                    objAdd.date = reader["date"].ToString();
                    objAdd.trxID = reader["trxID"].ToString();
                    objAdd.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objAdd.amountCoin = Convert.ToInt32(reader["amountCoin"]);
                    objAdd.medium = reader["medium"].ToString();
                    objAdd.cardID = reader["cardID"].ToString();
                    objAdd.isVoucherUsed = Convert.ToInt32(reader["isVoucherUsed"]);
                    objAdd.voucherID = Convert.ToInt32(reader["voucherID"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                StudentPaymentHistory objAdd = new StudentPaymentHistory();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentPaymentHistory> getStudentPaymentHistoryWithID(StudentPaymentHistory obj)
        {
            List<StudentPaymentHistory> objRList = new List<StudentPaymentHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudentPaymentHistoryWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentPaymentHistory objR = new StudentPaymentHistory();
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.paymentID = reader["paymentID"].ToString();
                    objR.date = reader["date"].ToString();
                    objR.trxID = reader["trxID"].ToString();
                    objR.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objR.amountCoin = Convert.ToInt32(reader["amountCoin"]);
                    objR.medium = reader["medium"].ToString();
                    objR.cardID = reader["cardID"].ToString();
                    objR.isVoucherUsed = Convert.ToInt32(reader["isVoucherUsed"]);
                    objR.name = reader["name"].ToString();
                    objR.voucherID = Convert.ToInt32(reader["voucherID"]);
                    objRList.Add(objR);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                StudentPaymentHistory objR = new StudentPaymentHistory();
                objR.Response = ex.Message;
                objRList.Add(objR);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setStudentPaymentHistory(StudentPaymentHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setStudentPaymentHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@paymentID", obj.paymentID);
                cmd.Parameters.AddWithValue("@date", obj.date);
                cmd.Parameters.AddWithValue("@trxID", obj.trxID);
                cmd.Parameters.AddWithValue("@amountTaka", obj.amountTaka);
                cmd.Parameters.AddWithValue("@amountCoin", obj.amountCoin);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@medium", obj.medium);
                cmd.Parameters.AddWithValue("@isVoucherUsed", obj.isVoucherUsed);
                cmd.Parameters.AddWithValue("@voucherID", obj.voucherID);
                cmd.Parameters.AddWithValue("@cardID", obj.cardID);
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
        public Response updateStudentPaymentHistory(StudentPaymentHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateStudentPaymentHistory", conn);
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


        #region StudentTuitionHistory
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentTuitionHistory> getStudentTuitionHistory()
        {
            List<StudentTuitionHistory> objRList = new List<StudentTuitionHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudentTuitionHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentTuitionHistory objAdd = new StudentTuitionHistory();
                    objAdd.studentID = Convert.ToInt32(reader["studentID"]);
                    objAdd.tuitionID = reader["tuitionID"].ToString();
                    objAdd.time = reader["time"].ToString();
                    objAdd.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objAdd.cost = Convert.ToInt32(reader["cost"]);
                    objAdd.ratting = Convert.ToInt32(reader["ratting"]);
                    objAdd.date = reader["date"].ToString();
                    objAdd.firstChoiceID = reader["firstChoiceID"].ToString();
                    objAdd.secondChoiceID = reader["secondChoiceID"].ToString();
                    objAdd.thirdChoiceID = reader["thirdChoiceID"].ToString();
                    objAdd.forthChoiceID = reader["forthChoiceID"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                StudentTuitionHistory objAdd = new StudentTuitionHistory();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<StudentTuitionHistory> getStudentTuitionHistoryWithID(StudentTuitionHistory obj)
        {
            List<StudentTuitionHistory> objRList = new List<StudentTuitionHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getStudentTuitionHistoryWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
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
        public StudentTuitionHistory getTuitionHistoryWithTuitionID(StudentTuitionHistory obj)
        {
            StudentTuitionHistory objR = new StudentTuitionHistory();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTuitionHistoryWithTuitionID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tuitionID", obj.tuitionID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
        public Response setStudentTuitionHistory(StudentTuitionHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setStudentTuitionHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@tuitionID", obj.tuitionID);
                cmd.Parameters.AddWithValue("@time", obj.time);
                cmd.Parameters.AddWithValue("@teacherID", obj.teacherID);
                cmd.Parameters.AddWithValue("@cost", obj.cost);
                cmd.Parameters.AddWithValue("@ratting", obj.ratting);
                cmd.Parameters.AddWithValue("@firstChoiceID", obj.firstChoiceID);
                cmd.Parameters.AddWithValue("@secondChoiceID", obj.secondChoiceID);
                cmd.Parameters.AddWithValue("@thirdChoiceID", obj.thirdChoiceID);
                cmd.Parameters.AddWithValue("@forthChoiceID", obj.forthChoiceID);
                cmd.Parameters.AddWithValue("@date", obj.date);
                cmd.Parameters.AddWithValue("@firstChoiceName", obj.firstChoiceName);
                cmd.Parameters.AddWithValue("@secondChoiceName", obj.secondChoiceName);
                cmd.Parameters.AddWithValue("@thirdChoiceName", obj.thirdChoiceName);
                cmd.Parameters.AddWithValue("@forthChoiceName", obj.forthChoiceName);
                cmd.Parameters.AddWithValue("@teacherName", obj.teacherName);
                cmd.Parameters.AddWithValue("@studentName", obj.studentName);
                cmd.Parameters.AddWithValue("@teacherEarn", obj.teacherEarn);
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
        public Response updateStudentTuitionHistory(StudentTuitionHistory obj)
        {
            Response response = new Response();
            try
            {

                Connection();
                SqlCommand cmd = new SqlCommand("updateStudentTuitionHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tuitionID", obj.tuitionID);
                cmd.Parameters.AddWithValue("@cost", obj.cost);
                cmd.Parameters.AddWithValue("@ratting", obj.ratting);
                cmd.Parameters.AddWithValue("@teacherEarn", obj.teacherEarn);
                cmd.Parameters.AddWithValue("@time", obj.time);
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
        public Response FinalizeTuitionHistory(StudentTuitionHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("FinalizeTuitionHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ratting", obj.ratting);
                cmd.Parameters.AddWithValue("@tuitionID", obj.tuitionID);
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


        #region Subject
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Subject> getSubject()
        {
            List<Subject> objRList = new List<Subject>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSubject", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject objAdd = new Subject();
                    objAdd.classID = Convert.ToInt32(reader["classID"]);
                    objAdd.subjectID = Convert.ToInt32(reader["subjectID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.name = reader["name"].ToString();
                    objAdd.groupName = reader["groupName"].ToString();
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Subject objAdd = new Subject();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Subject getSubjectWithID(Subject obj)
        {
            Subject objR = new Subject();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSubjectWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@classID", obj.classID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.classID = Convert.ToInt32(reader["classID"]);
                    objR.subjectID = Convert.ToInt32(reader["subjectID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.groupName = reader["groupName"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo "]);

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
        public Response setSubject(Subject obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setSubject", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@classID", obj.classID);
                cmd.Parameters.AddWithValue("@subjectID", obj.subjectID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@groupName", obj.groupName);
                cmd.Parameters.AddWithValue("@tuitionRequest", 0);
                cmd.Parameters.AddWithValue("@avgRatting", 0);
                cmd.Parameters.AddWithValue("@indexNo ", 0);
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
        public Response updateSubject(Subject obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateSubject", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@classID", obj.classID);
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


        #region UniversityName
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<UniversityName> getUniversityName()
        {
            List<UniversityName> objRList = new List<UniversityName>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getUniversityName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UniversityName objAdd = new UniversityName();
                    objAdd.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objAdd.title = reader["title"].ToString();
                    objAdd.name = reader["name"].ToString();
                    objAdd.avgRatting = Convert.ToDouble(reader["avgRatting"]);
                    objAdd.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objAdd.indexNo = Convert.ToInt32(reader["indexNo"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                UniversityName objAdd = new UniversityName();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public UniversityName getUniversityNameWithID(UniversityName obj)
        {
            UniversityName objR = new UniversityName();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getUniversityNameWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.uniNameID = Convert.ToInt32(reader["uniNameID"]);
                    objR.title = reader["title"].ToString();
                    objR.name = reader["name"].ToString();
                    objR.tuitionRequest = Convert.ToInt32(reader["tuitionRequest"]);
                    objR.indexNo = Convert.ToInt32(reader["indexNo"]);

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
        public Response setUniversityName(UniversityName obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setUniversityName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@tuitionRequest", obj.tuitionRequest);
                cmd.Parameters.AddWithValue("@avgRatting", obj.avgRatting);
                cmd.Parameters.AddWithValue("@indexNo ", obj.indexNo);
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
        public Response updateUniversityName(UniversityName obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateUniversityName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniNameID", obj.uniNameID);
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

      
        #region Voucher
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Voucher> getVoucher()
        {
            List<Voucher> objRList = new List<Voucher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Voucher objAdd = new Voucher();
                    objAdd.voucherID = Convert.ToInt32(reader["voucherID"]);
                    objAdd.name = reader["name"].ToString();
                    objAdd.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objAdd.getAmount = Convert.ToInt32(reader["getAmount"]);
                    objAdd.type = Convert.ToInt32(reader["type"]);
                    objAdd.validFrom = reader["validFrom"].ToString();
                    objAdd.validTo = reader["validTo"].ToString();
                    objAdd.voucherImageSrc = reader["voucherImageSrc"].ToString();
                    objAdd.canUse = Convert.ToInt32(reader["canUse"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Voucher objAdd = new Voucher();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Voucher getVoucherWithID(Voucher obj)
        {
            Voucher objR = new Voucher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getVoucherWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@voucherID", obj.voucherID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.voucherID = Convert.ToInt32(reader["voucherID"]);
                    objR.name = reader["name"].ToString();
                    objR.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objR.getAmount = Convert.ToInt32(reader["getAmount"]);
                    objR.type = Convert.ToInt32(reader["type"]);
                    objR.validFrom = reader["validFrom"].ToString();
                    objR.validTo = reader["validTo"].ToString();
                    objR.voucherImageSrc = reader["voucherImageSrc"].ToString();
                    objR.canUse = Convert.ToInt32(reader["canUse"]);

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
        public Response setVoucher(Voucher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@voucherID", obj.voucherID);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.Parameters.AddWithValue("@amountTaka", obj.amountTaka);
                cmd.Parameters.AddWithValue("@getAmount", obj.getAmount);
                cmd.Parameters.AddWithValue("@type", obj.type);
                cmd.Parameters.AddWithValue("@validFrom", obj.validFrom);
                cmd.Parameters.AddWithValue("@validTo", obj.validTo);
                cmd.Parameters.AddWithValue("@voucherImageSrc", obj.voucherImageSrc);
                cmd.Parameters.AddWithValue("@canUse", obj.canUse);
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
        public Response updateVoucher(Voucher obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateVoucher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@voucherID", obj.voucherID);
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


        #region VoucherHistory
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<VoucherHistory> getVoucherHistory()
        {
            List<VoucherHistory> objRList = new List<VoucherHistory>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getVoucherHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VoucherHistory objAdd = new VoucherHistory();
                    objAdd.studentID = Convert.ToInt32(reader["studentID"]);
                    objAdd.voucherHistoryID = Convert.ToInt32(reader["voucherHistoryID"]);
                    objAdd.paymentID = Convert.ToInt32(reader["paymentID"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                VoucherHistory objAdd = new VoucherHistory();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public VoucherHistory getVoucherHistoryWithID(VoucherHistory obj)
        {
            VoucherHistory objR = new VoucherHistory();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getVoucherHistoryWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.voucherHistoryID = Convert.ToInt32(reader["voucherHistoryID"]);
                    objR.paymentID = Convert.ToInt32(reader["paymentID"]);

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
        public Response setVoucherHistory(VoucherHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setVoucherHistory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID", obj.studentID);
                cmd.Parameters.AddWithValue("@voucherHistoryID", obj.voucherHistoryID);
                cmd.Parameters.AddWithValue("@paymentID", obj.paymentID);
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
        public Response updateVoucherHistory(VoucherHistory obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateVoucherHistory", conn);
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

        #region Hire Teacher 
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<Teacher> HireTeacherAsync(HireTeacher obj)
        {
            Response objR = new Response();
            Teacher SelectedTuitionTeacherToCall = new Teacher();
            List<Teacher> matchedTeacherList = new List<Teacher>();
            int SelectedIndex = 0;
            List<Teacher> SortedList = new List<Teacher>();
            List<Teacher> SelectedTeacherList = new List<Teacher>();
            List<float> teacherPointList = new List<float>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getTeacherIDWithSubID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subID", obj.subID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher matchedTeacher = new Teacher();
                    matchedTeacher.teacherID = Convert.ToInt32(reader["teacherID"]);
                    matchedTeacher.activeTime = reader["activeTime"].ToString();
                    matchedTeacherList.Add(matchedTeacher);
                }
                conn.Close();

                
              
                int pointListCount = 0;
                SortedList = matchedTeacherList.OrderBy(x => x.activeTime).ToList();
                for (int i = 0; i < 5; i++)
                {
                    Teacher thisTeacher = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/getTeacherWithID".PostUrlEncodedAsync(new { teacherID = SortedList[i].teacherID })
          .ReceiveJson<Teacher>();
                    if(thisTeacher.activeStatus == 1)
                    {
                        SelectedTeacherList.Add(thisTeacher);
                        SelectedTeacherList[i].activeTime = matchedTeacherList[i].activeTime;
                    }
                    if (i == SortedList.Count - 1)
                    {
                        break;
                    }
                }              

                for(int i = 0; i < 5; i++)
                {
                    float thispoint = (5 - i) * 2f + CalculateRatting(SelectedTeacherList[i].fiveStar, SelectedTeacherList[i].fourStar, SelectedTeacherList[i].threeStar, SelectedTeacherList[i].twoStar, SelectedTeacherList[i].oneStar) * 4.1f;
                    teacherPointList.Add (thispoint) ;
                    if (i == SortedList.Count-1)
                    {
                        break;
                    }
                }
                float max = teacherPointList[0];
              
                for (int i = 0; i < teacherPointList.Count; i++)
                {
                    if(max < teacherPointList[i])
                    {
                        max = teacherPointList[i];
                        SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                //SelectedTuitionTeacherToCall.Response = ex.Message + " " + SelectedIndex;
            }
            return SelectedTeacherList[SelectedIndex];
        }
        #endregion

        #region Video Call Api Creator
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public VideoApiInfo GetVideoCallInfo()
        {
            VideoApiInfo inf0 = new VideoApiInfo();
            try
            {
                VideoCallAPiMaker maker = new VideoCallAPiMaker();
                inf0.apiKey = VideoCallAPiMaker.Apikey;
                inf0.SessionID = VideoCallAPiMaker.Session.Id;
                inf0.token = VideoCallAPiMaker.Token;
            }
            catch (Exception ex)
            {
                inf0.Response = ex.Message;
            }
            return inf0;
        }
        #endregion

        #region Video CAll Per Min Api Call
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<PerMinCallResponse> PerMinPassCall(PerMinPassModel obj)
        {
            PerMinCallResponse res = new PerMinCallResponse();
            try
            {
                Student student = new Student();
                Teacher teacher = new Teacher();
                student = await "https://api.shikkhanobish.com/api/ShikkhanobishLogin/getStudentWithID".PostUrlEncodedAsync(new { studentID = obj.studentID })
      .ReceiveJson<Student>();
                teacher = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/getTeacherWithID".PostUrlEncodedAsync(new { teacherID = obj.teacherID })
      .ReceiveJson<Teacher>();
                int cost = CalculateStudentCost(int.Parse(obj.firstChoiceID),student);
                double teacherEarn = CalculateTeacherEarn(teacher, int.Parse(obj.firstChoiceID));
                bool firstTime;
                if (obj.time == 1)
                {
                    await CreateNewTuitionHistory(student,teacher,obj, cost, teacherEarn);
                    firstTime = true;
                }
                else
                {
                   await UpdateTuitionHistory(obj,cost,teacherEarn);
                    firstTime = false;
                }
                await UpdateStudent(student, cost);
                await UpdateTeacher(teacher, firstTime, teacherEarn);
                res.Massage = "All Ok";
                res.cost = cost;
                res.earned = teacherEarn;
                res.Status = 0;
            }
            catch (Exception ex)
            {
                res.Massage = ex.Message;
                res.Status = 1;
            }
            return res;
        }
       
        public async Task CreateNewTuitionHistory(Student st, Teacher th, PerMinPassModel prmc,int cost,double teacherearn)
        {
            var res = await "https://api.shikkhanobish.com/api/ShikkhanobishLogin/setStudentTuitionHistory".PostUrlEncodedAsync(new { 
                studentID = st.studentID,
                tuitionID = prmc.sessionID,
                time = prmc.time,
                teacherID = th.teacherID,
                cost = cost,
                ratting = 0,
                firstChoiceID = prmc.firstChoiceID,
                secondChoiceID = prmc.secondChoiceID,
                thirdChoiceID = prmc.thirdChoiceID,
                forthChoiceID = prmc.firstChoiceID,
                date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                studentName = st.name,
                teacherName = th.name,
                firstChoiceName = prmc.firstChoiceName,
                secondChoiceName = prmc.secondChoiceName,
                thirdChoiceName = prmc.thirdChoiceName,
                forthChoiceName = prmc.forthChoiceName,
                teacherEarn = teacherearn
            })
      .ReceiveJson<Response>();
            
        }
        public async Task UpdateTuitionHistory(PerMinPassModel prmc, int cost, double earn)
        {
            int totalCost = cost * prmc.time;
            double totalEarn = earn * prmc.time;
            var res = await "https://api.shikkhanobish.com/api/ShikkhanobishLogin/updateStudentTuitionHistory".PostUrlEncodedAsync(new
            {
                tuitionID = prmc.sessionID,
                time = prmc.time,
                cost = totalCost,
                ratting = 0,
                teacherEarn = totalEarn
            }).ReceiveJson<Response>();
        }
        public async Task UpdateStudent(Student student ,int cost)
        {
            if(cost == 0)
            {
                student.freemin -= 1;
            }
            else
            {
                student.totalSpent += cost;
                student.coin -= cost;
            }
            Response regRes = await "https://api.shikkhanobish.com/api/ShikkhanobishLogin/updateStudent"
                .PostUrlEncodedAsync(new
                {
                    studentID = student.studentID,
                    phonenumber = student.phonenumber,
                    password = student.password,
                    totalSpent = student.totalSpent,
                    totalTuitionTime = (student.totalTuitionTime+1),
                    coin = student.coin,
                    freemin = student.freemin,
                    city = student.city,
                    name = student.name,
                    institutionName = "none"
                })
                .ReceiveJson<Response>();
        }
        public async Task UpdateTeacher(Teacher teacher, bool firstTime, double earn)
        {
            if(firstTime)
            {
                teacher.totalTuition += 1;
            }
            if(teacher.totalMinuite >= 20)
            {
                teacher.monetizetionStatus = 1;
            }
            Response regRes = await "https://api.shikkhanobish.com/api/ShikkhanobishTeacher/updateTeacherInfo"
                .PostUrlEncodedAsync(new
                {
                    teacherID = teacher.teacherID,
                    name = teacher.name,
                    password = teacher.password,
                    phonenumber = teacher.phonenumber,
                    selectionStatus = teacher.selectionStatus,
                    monetizetionStatus = teacher.monetizetionStatus,
                    totalMinuite = teacher.totalMinuite+1,
                    favTeacherCount = teacher.favTeacherCount,
                    reportCount = teacher.reportCount,
                    totalTuition = teacher.totalTuition,
                    fiveStar = teacher.fiveStar,
                    fourStar = teacher.fourStar,
                    threeStar = teacher.threeStar,
                    twoStar = teacher.twoStar,
                    oneStar = teacher.oneStar,
                    amount = teacher.amount+ earn,
                    activeStatus = teacher.activeStatus
                })
                .ReceiveJson<Response>();
        }
        public int CalculateStudentCost(int insID, Student student)
        {
            int cost = 0;
            bool isCostAvaiable;
            if (student.freemin == 0)
            {
                isCostAvaiable = true;

            }
            else
            {
                isCostAvaiable = false;
            }
            
            if(isCostAvaiable)
            {
                if (insID == 101)
                {
                    cost = SchoolCost;
                }
                if (insID == 102)
                {
                    cost = CollegeCost;
                }
            }
            else
            {
                cost = 0;
            }
            
            return cost;
        }
        public double CalculateTeacherEarn(Teacher teacher,  int insID)
        {
            double earn = 0;
            if(teacher.monetizetionStatus == 0)
            {
                earn = 0;
            }
            else
            {
                if(insID == 101)
                {
                    earn = SchoolCost * 0.80;
                }
                if(insID == 102)
                {
                    earn = CollegeCost * 0.80;
                }
            }
            return earn;
        }
        /*
         * studentID: 10000003, 
teacherID:	23926316
time:1
sessionID:'fghfgh543dgffd45sf'
firstChoiceID:101
secondChoiceID:101
thirdChoiceID:101
forthChoiceID:101
firstChoiceName:'School'
secondChoiceName:'Class 6'
thirdChoiceName:'Physics First Paper'
forthChoiceName: 'Chapter 1'
         */
        #endregion

        #region Get Cost
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public CostClass GetCost()
        {
            CostClass allCost = new CostClass();
            allCost.SchoolCost = SchoolCost;
            allCost.CollegeCost = CollegeCost;
            allCost.ProcessignCostPercent = processignCostPercent;
            return allCost;
        }
        #endregion

        #region Dashboard
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<DashBoardUser> GetDashBoardUser()
        {
            List<DashBoardUser> objRList = new List<DashBoardUser>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetDashBoardUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DashBoardUser objAdd = new DashBoardUser();
                    objAdd.userID = Convert.ToInt32(reader["userID"]);
                    objAdd.name = reader["name"].ToString();
                    objAdd.password = reader["password"].ToString();
                    objAdd.type = reader["type"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                DashBoardUser objAdd = new DashBoardUser();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }
        #endregion

        #region RequestPayemnt
        private string paymentGatewayBase = WebConfigurationManager.AppSettings["baseUrl"];
        string Baseurl = WebConfigurationManager.AppSettings["baseUrl"] + "/request.php";
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task<String> RequestPayment(requestPayment obj)
        {
            string messgae = "";
            string url;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            TransactionModel rq = new TransactionModel();

            rq.tran_id = RandomString(10);
            rq.cus_name = obj.name;
            rq.amount = obj.amount +"" ;
            rq.cus_phone = obj.phonenumber;
            rq.opt_a = obj.studentID.ToString();
            rq.cus_email = "mahirmuzahid@gmail.com";

            rq.success_url = "https://api.shikkhanobish.com/api/ShikkhanobishLogin/CallBackPaymentSuccessFull";
            rq.fail_url = "https://api.shikkhanobish.com/api/ShikkhanobishLogin/CallBackPaymentFailed";
            rq.cancel_url = "https://api.shikkhanobish.com/api/ShikkhanobishLogin/CallBackPaymentCancle";

            PropertyInfo[] infos = rq.GetType().GetProperties();

            foreach (PropertyInfo pair in infos)
            {
                string name = pair.Name;
                var value = pair.GetValue(rq, null);

                parameters.Add(pair.Name, value.ToString());
            }
            using (var client = new HttpClient())
            {
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);

                using (
                    var result =
                        await client.PostAsync(Baseurl, DictionaryItems))
                {
                    var input = await result.Content.ReadAsStringAsync();
                    var trans = input.Remove(0, 2).Split('"')[0];                   
                    url = paymentGatewayBase + trans;
                }
            }
            return url;
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task CallBackPaymentSuccessFull(CallBackPayment obj)
        {
            string url = "https://shikkhanobishrealtimeapi.shikkhanobish.com/api/ShikkhanobishSignalR/StudentPaymentStatus?&studentID=" + obj.opt_a + "&successFullPayment=" + true + "&amount=" + obj.amount + "&response=ok" + "&paymentID=" + obj.mer_txnid + "&trxID=" + obj.bank_txn + "&cardID="+obj.card_number+ "&cardType="+obj.card_type;
            HttpClient client = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(true);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task CallBackPaymentFailed(CallBackPayment obj)
        {
            string url = "https://shikkhanobishrealtimeapi.shikkhanobish.com/api/ShikkhanobishSignalR/StudentPaymentStatus?&studentID=" + obj.opt_a + "&successFullPayment=" + false + "&amount=" + obj.amount + "&response=" + obj.pg_error_code_details + "&paymentID=" + obj.mer_txnid + "&trxID=" + obj.bank_txn + "&cardID=" + obj.card_number + "&cardType=" + obj.card_type;
            HttpClient client = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(true);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public async Task CallBackPaymentCancle(CallBackPayment obj)
        {
            string url = "https://shikkhanobishrealtimeapi.shikkhanobish.com/api/ShikkhanobishSignalR/StudentPaymentStatus?&studentID=" + obj.opt_a + "&successFullPayment=" + false + "&amount=" + obj.amount + "&response=" + obj.pg_error_code_details + "&paymentID=" + obj.mer_txnid + "&trxID=" + obj.bank_txn + "&cardID=" + obj.card_number + "&cardType=" + obj.card_type;
            HttpClient client = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(true);
        }
        #endregion

        #region ImageSource
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<PromotionalImage> GetPromotionalImage()
        {
            List<PromotionalImage> objRList = new List<PromotionalImage>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetPromotionalImage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromotionalImage objAdd = new PromotionalImage();
                    objAdd.imgSource = reader["imgSource"].ToString();
                    objRList.Add(objAdd); 
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                PromotionalImage objAdd = new PromotionalImage();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }
        #endregion

        #region GetImageSource
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<PromotionalMassage> GetPromotionalMassage()
        {
            List<PromotionalMassage> objRList = new List<PromotionalMassage>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("GetPromotionalMassage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromotionalMassage objAdd = new PromotionalMassage();
                    objAdd.imageSrc = reader["imageSrc"].ToString();
                    objAdd.msgType = Convert.ToInt32(reader["msgType"]);
                    objAdd.userType = reader["userType"].ToString();
                    objAdd.text = reader["text"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                PromotionalMassage objAdd = new PromotionalMassage();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }
        #endregion

    }
}