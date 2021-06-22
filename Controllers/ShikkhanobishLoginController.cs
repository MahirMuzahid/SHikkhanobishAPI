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
                cmd.Parameters.AddWithValue("@tuitionRequest", obj.tuitionRequest);
                cmd.Parameters.AddWithValue("@avgRatting", obj.avgRatting);
                cmd.Parameters.AddWithValue("@indexNo", obj.indexNo);
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
                    objAdd.paymentID = Convert.ToInt32(reader["paymentID"]);
                    objAdd.date = reader["date"].ToString();
                    objAdd.trxID = reader["trxID"].ToString();
                    objAdd.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objAdd.amountCoin = Convert.ToInt32(reader["amountCoin"]);
                    objAdd.medium = Convert.ToInt32(reader["medium"]);
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
        public StudentPaymentHistory getStudentPaymentHistoryWithID(StudentPaymentHistory obj)
        {
            StudentPaymentHistory objR = new StudentPaymentHistory();
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
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.paymentID = Convert.ToInt32(reader["paymentID"]);
                    objR.date = reader["date"].ToString();
                    objR.trxID = reader["trxID"].ToString();
                    objR.amountTaka = Convert.ToInt32(reader["amountTaka"]);
                    objR.amountCoin = Convert.ToInt32(reader["amountCoin"]);
                    objR.medium = Convert.ToInt32(reader["medium"]);
                    objR.isVoucherUsed = Convert.ToInt32(reader["isVoucherUsed"]);
                    objR.name = reader["name"].ToString();
                    objR.voucherID = Convert.ToInt32(reader["voucherID"]);

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
                cmd.Parameters.AddWithValue("@medium", obj.medium);
                cmd.Parameters.AddWithValue("@isVoucherUsed", obj.isVoucherUsed);
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
                    objAdd.tuitionID = Convert.ToInt32(reader["tuitionID"]);
                    objAdd.time = reader["time"].ToString();
                    objAdd.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objAdd.cost = Convert.ToInt32(reader["cost"]);
                    objAdd.ratting = Convert.ToInt32(reader["ratting"]);
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
        public StudentTuitionHistory getStudentTuitionHistoryWithID(StudentTuitionHistory obj)
        {
            StudentTuitionHistory objR = new StudentTuitionHistory();
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
                    objR.studentID = Convert.ToInt32(reader["studentID"]);
                    objR.tuitionID = Convert.ToInt32(reader["tuitionID"]);
                    objR.time = reader["time"].ToString();
                    objR.teacherID = Convert.ToInt32(reader["teacherID"]);
                    objR.cost = Convert.ToInt32(reader["cost"]);
                    objR.ratting = Convert.ToInt32(reader["ratting"]);
                    objR.firstChoiceID = reader["firstChoiceID"].ToString();
                    objR.secondChoiceID = reader["secondChoiceID"].ToString();
                    objR.thirdChoiceID = reader["thirdChoiceID"].ToString();
                    objR.forthChoiceID = reader["forthChoiceID"].ToString();
                    objR.studentName = reader["studentName"].ToString();
                    objR.teacherName = reader["teacherName"].ToString();
                    objR.date = reader["date"].ToString();

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
    }
}