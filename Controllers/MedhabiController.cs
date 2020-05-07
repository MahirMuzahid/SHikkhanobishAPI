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
                cmd.Parameters.AddWithValue("@teacherID", q.teacherID);


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
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

        [AcceptVerbs("GET", "POST")]
        public medhabiStudent SignIn(medhabiStudent s)
        {
            medhabiStudent student = new medhabiStudent();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mail", s.mail);
                cmd.Parameters.AddWithValue("@password", s.password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    student.studentID = Convert.ToInt32(reader["studentID"]);
                    student.mail = reader["mail"].ToString();
                    student.password = reader["password"].ToString();
                    student.name = reader["name"].ToString();
                    student.phonenumber = reader["phonenumber"].ToString();
                    student.amount = Convert.ToInt32(reader["amount"]);
                    student.point = Convert.ToInt32(reader["point"]);
                    student.rank = reader["rank"].ToString();
                    student.total_question_answered = Convert.ToInt32(reader["total_question_answered"]);
                    student.total_right_answer = Convert.ToInt32(reader["total_right_answer"]);
                    student.response = "Ok";
                    student.stetus = 0;
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                student.response = ex.Message;
                student.stetus = 1;
            }

            return student;
        }


        [AcceptVerbs("GET", "POST")]
        public Response SignUp(medhabiStudent s)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.setStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mail", s.mail);
                cmd.Parameters.AddWithValue("@password", s.password);
                cmd.Parameters.AddWithValue("@name", s.name);
                cmd.Parameters.AddWithValue("@phonenumber ", s.phonenumber);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Registered";
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
        public medhabiTeacher SignInTeacher(medhabiTeacher s)
        {
            medhabiTeacher Teacher = new medhabiTeacher();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mail", s.mail);
                cmd.Parameters.AddWithValue("@password", s.password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher.teacherID = Convert.ToInt32(reader["teacherID"]);
                    Teacher.mail = reader["mail"].ToString();
                    Teacher.password = reader["password"].ToString();
                    Teacher.name = reader["name"].ToString();
                    Teacher.phonenumber = reader["phonenumber"].ToString();
                    Teacher.amount = Convert.ToInt32(reader["amount"]);
                    Teacher.posted_question = Convert.ToInt32(reader["posted_question"]);
                    Teacher.rank = reader["rank"].ToString();
                    Teacher.response = "Ok";
                    Teacher.stetus = 0;
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                Teacher.response = ex.Message;
                Teacher.stetus = 1;
            }

            return Teacher;
        }
        [AcceptVerbs("GET", "POST")]
        public IEnumerable< medhabiStudent> GetTopStudents()
        {
            List<medhabiStudent> studentList = new List<medhabiStudent>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getTopStudent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medhabiStudent student = new medhabiStudent();
                    student.studentID = Convert.ToInt32(reader["studentID"]);
                    student.name = reader["name"].ToString();
                    student.point = Convert.ToInt32(reader["point"]);
                    student.rank = reader["rank"].ToString();
                    student.total_question_answered = Convert.ToInt32(reader["total_question_answered"]);
                    student.total_right_answer = Convert.ToInt32(reader["total_right_answer"]);
                    student.response = "Ok";
                    student.stetus = 0;
                    studentList.Add(student);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                medhabiStudent student = new medhabiStudent();
                student.response = ex.Message;
                student.stetus = 1;
                studentList.Add(student);
            }

            return studentList;
        }


        [AcceptVerbs("GET", "POST")]
        public IEnumerable<medhabiTeacher> GetTopTeacher()
        {
            List<medhabiTeacher> TeacherList = new List<medhabiTeacher>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getTopTeacher", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medhabiTeacher Teacher = new medhabiTeacher();
                    Teacher.teacherID = Convert.ToInt32(reader["teacherID"]);
                    Teacher.name = reader["name"].ToString();
                    Teacher.amount = Convert.ToInt32(reader["amount"]);
                    Teacher.posted_question = Convert.ToInt32(reader["posted_question"]);
                    Teacher.rank = reader["rank"].ToString();
                    Teacher.response = "Ok";
                    Teacher.stetus = 0;
                    TeacherList.Add(Teacher);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                medhabiTeacher Teacher = new medhabiTeacher();
                Teacher.response = ex.Message;
                Teacher.stetus = 1;
                TeacherList.Add(Teacher);
            }

            return TeacherList;
        }


        [AcceptVerbs("GET", "POST")]
        public Response SetMachMaking(MatchMaking s)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.setInMatchmaking ", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstPlayerID", s.firstPlayerID);
                cmd.Parameters.AddWithValue("@matchID", s.matchID);
                cmd.Parameters.AddWithValue("@firstQuestionID", s.firstQuestionID);
                cmd.Parameters.AddWithValue("@secondQuestionID", s.secondQuestionID);
                cmd.Parameters.AddWithValue("@thirdQuestionID", s.thirdQuestionID);
                cmd.Parameters.AddWithValue("@forthQuestionID", s.forthQuestionID);
                cmd.Parameters.AddWithValue("@fifthQuestionID", s.fifthQuestionID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Placed in Machmaking";
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
        public IEnumerable<MatchMaking> GetMatchMaking()
        {
            List<MatchMaking> mmList = new List<MatchMaking>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getInMatchmaking", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MatchMaking mm = new MatchMaking();
                    mm.firstPlayerID = Convert.ToInt32(reader["firstPlayerID"]);
                    mm.matchID = reader["matchID"].ToString();
                    mm.firstQuestionID = Convert.ToInt32(reader["firstQuestionID"]);
                    mm.secondQuestionID = Convert.ToInt32(reader["secondQuestionID"]);
                    mm.thirdQuestionID = Convert.ToInt32(reader["thirdQuestionID"]);
                    mm.forthQuestionID = Convert.ToInt32(reader["forthQuestionID"]);
                    mm.fifthQuestionID = Convert.ToInt32(reader["fifthQuestionID"]);
                    mm.response = "Ok";
                    mm.stetus = 0;
                    mmList.Add(mm);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MatchMaking mm = new MatchMaking();
                mm.response = ex.Message;
                mm.stetus = 1;
                mmList.Add(mm);
            }

            return mmList;
        }

        [AcceptVerbs("GET", "POST")]
        public MatchMaking DeleteIfFoundMatch(MatchMaking s)
        {
            MatchMaking mm = new MatchMaking();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.DeleteIfFoundMatch ", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@playerID", s.firstPlayerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mm.firstPlayerID = Convert.ToInt32(reader["firstPlayerID"]);
                    mm.matchID = reader["matchID"].ToString();
                    mm.firstQuestionID = Convert.ToInt32(reader["firstQuestionID"]);
                    mm.secondQuestionID = Convert.ToInt32(reader["secondQuestionID"]);
                    mm.thirdQuestionID = Convert.ToInt32(reader["thirdQuestionID"]);
                    mm.forthQuestionID = Convert.ToInt32(reader["forthQuestionID"]);
                    mm.fifthQuestionID = Convert.ToInt32(reader["fifthQuestionID"]);
                    mm.response = "Ok";
                    mm.stetus = 0;
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                mm.response = ex.Message;
                mm.stetus = 1;
            }

            return mm;
        }


        [AcceptVerbs("GET", "POST")]
        public IEnumerable<Questions> MakeQuestion( QuestionMaker qs)
        {
            List<Questions> questionList = new List<Questions>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.createQuestionAllSubject ", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstqsID", qs.firstqsID);
                cmd.Parameters.AddWithValue("@secondID", qs.secondID);
                cmd.Parameters.AddWithValue("@thirdID", qs.thirdID);
                cmd.Parameters.AddWithValue("@forthID", qs.forthID);
                cmd.Parameters.AddWithValue("@fifthID", qs.fifthID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Questions question = new Questions();
                    question.question_code= reader["question_code"].ToString();
                    question.question = reader["question"].ToString();
                    question.first_choice = reader["first_choice"].ToString();
                    question.second_choice = reader["second_choice"].ToString();
                    question.third_choice = reader["third_choice"].ToString();
                    question.forth_choice = reader["forth_choice"].ToString();
                    question.right_answer = Convert.ToInt32(reader["right_answer"]);
                    question.questionID = Convert.ToInt32(reader["questionID"]);
                    question.response = "Ok";
                    question.stetus = 0;
                    questionList.Add(question);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                Questions question = new Questions();
                question.response = ex.Message;
                question.stetus = 1;
                questionList.Add(question);
            }

            return questionList;
        }


        [AcceptVerbs("GET", "POST")]
        public medhabiStudent GetInfoFromId(medhabiStudent s)
        {
            medhabiStudent student = new medhabiStudent();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getInfoFromID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID ", s.studentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    student.studentID = Convert.ToInt32(reader["studentID"]);
                    student.mail = reader["mail"].ToString();
                    student.password = reader["password"].ToString();
                    student.name = reader["name"].ToString();
                    student.phonenumber = reader["phonenumber"].ToString();
                    student.amount = Convert.ToInt32(reader["amount"]);
                    student.point = Convert.ToInt32(reader["point"]);
                    student.rank = reader["rank"].ToString();
                    student.total_question_answered = Convert.ToInt32(reader["total_question_answered"]);
                    student.total_right_answer = Convert.ToInt32(reader["total_right_answer"]);
                    student.response = "Ok";
                    student.stetus = 0;
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                student.response = ex.Message;
                student.stetus = 1;
            }

            return student;
        }

        [AcceptVerbs("GET", "POST")]
        public Response DidactPoint(medhabiStudent s)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.DidectecPoint", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentID ", s.studentID);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    response.Massage = "Done";
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
        public Response ConfirmQs(Questions q)
        {
            int x = 0;
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("Shikkha1.getQsFromID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@questionID", q.questionID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    x = Convert.ToInt32(reader["result"]);
                    response.Massage = "OK";
                    response.Status = x;
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
