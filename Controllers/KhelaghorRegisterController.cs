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
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response RegUserInAllGame(RegUserInAllGame obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("RegUserInAllGame", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
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

        #region UltimateTicTacToe
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<UltimateTicTacToe> getUltimateTicTacToe()
        {
            List<UltimateTicTacToe> objRList = new List<UltimateTicTacToe>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getUltimateTicTacToe", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UltimateTicTacToe objAdd = new UltimateTicTacToe();
                    objAdd.ULGameID = Convert.ToInt32(reader["ULGameID"]);
                    objAdd.RankID = Convert.ToInt32(reader["RankID"]);
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objAdd.Win = Convert.ToInt32(reader["Win"]);
                    objAdd.Loose = Convert.ToInt32(reader["Loose"]);
                    objAdd.Draw = Convert.ToInt32(reader["Draw"]);
                    objAdd.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
                    objAdd.Name = reader["Name"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                UltimateTicTacToe objAdd = new UltimateTicTacToe();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public UltimateTicTacToe getUltimateTicTacToeWithID(UltimateTicTacToe obj)
        {
            UltimateTicTacToe objR = new UltimateTicTacToe();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getUltimateTicTacToeWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ULGameID", obj.ULGameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.ULGameID = Convert.ToInt32(reader["ULGameID"]);
                    objR.RankID = Convert.ToInt32(reader["RankID"]);
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objR.Win = Convert.ToInt32(reader["Win"]);
                    objR.Loose = Convert.ToInt32(reader["Loose"]);
                    objR.Draw = Convert.ToInt32(reader["Draw"]);
                    objR.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
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

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setUltimateTicTacToe(UltimateTicTacToe obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setUltimateTicTacToe", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ULGameID", obj.ULGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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
        public Response updateUltimateTicTacToe(UltimateTicTacToe obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateUltimateTicTacToe", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ULGameID", obj.ULGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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


        #region Checkers
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Checkers> getCheckers()
        {
            List<Checkers> objRList = new List<Checkers>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCheckers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Checkers objAdd = new Checkers();
                    objAdd.CHGameID = Convert.ToInt32(reader["CHGameID"]);
                    objAdd.RankID = Convert.ToInt32(reader["RankID"]);
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objAdd.Win = Convert.ToInt32(reader["Win"]);
                    objAdd.Loose = Convert.ToInt32(reader["Loose"]);
                    objAdd.Draw = Convert.ToInt32(reader["Draw"]);
                    objAdd.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
                    objAdd.Name = reader["Name"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Checkers objAdd = new Checkers();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Checkers getCheckersWithID(Checkers obj)
        {
            Checkers objR = new Checkers();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getCheckersWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CHGameID", obj.CHGameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.CHGameID = Convert.ToInt32(reader["CHGameID"]);
                    objR.RankID = Convert.ToInt32(reader["RankID"]);
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objR.Win = Convert.ToInt32(reader["Win"]);
                    objR.Loose = Convert.ToInt32(reader["Loose"]);
                    objR.Draw = Convert.ToInt32(reader["Draw"]);
                    objR.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
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

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setCheckers(Checkers obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setCheckers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CHGameID", obj.CHGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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
        public Response updateCheckers(Checkers obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateCheckers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CHGameID", obj.CHGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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


        #region Slitherlink
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Slitherlink> getSlitherlink()
        {
            List<Slitherlink> objRList = new List<Slitherlink>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSlitherlink", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Slitherlink objAdd = new Slitherlink();
                    objAdd.SLGameID = Convert.ToInt32(reader["SLGameID"]);
                    objAdd.RankID = Convert.ToInt32(reader["RankID"]);
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objAdd.Win = Convert.ToInt32(reader["Win"]);
                    objAdd.Loose = Convert.ToInt32(reader["Loose"]);
                    objAdd.Draw = Convert.ToInt32(reader["Draw"]);
                    objAdd.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
                    objAdd.Name = reader["Name"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Slitherlink objAdd = new Slitherlink();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Slitherlink getSlitherlinkWithID(Slitherlink obj)
        {
            Slitherlink objR = new Slitherlink();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSlitherlinkWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SLGameID", obj.SLGameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.SLGameID = Convert.ToInt32(reader["SLGameID"]);
                    objR.RankID = Convert.ToInt32(reader["RankID"]);
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objR.Win = Convert.ToInt32(reader["Win"]);
                    objR.Loose = Convert.ToInt32(reader["Loose"]);
                    objR.Draw = Convert.ToInt32(reader["Draw"]);
                    objR.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
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

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setSlitherlink(Slitherlink obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setSlitherlink", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SLGameID", obj.SLGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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
        public Response updateSlitherlink(Slitherlink obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateSlitherlink", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SLGameID", obj.SLGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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


        #region Futoshiki
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Futoshiki> getFutoshiki()
        {
            List<Futoshiki> objRList = new List<Futoshiki>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFutoshiki", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Futoshiki objAdd = new Futoshiki();
                    objAdd.FTGameID = Convert.ToInt32(reader["FTGameID"]);
                    objAdd.RankID = Convert.ToInt32(reader["RankID"]);
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objAdd.WIn = Convert.ToInt32(reader["WIn"]);
                    objAdd.Loose = Convert.ToInt32(reader["Loose"]);
                    objAdd.Draw = Convert.ToInt32(reader["Draw"]);
                    objAdd.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
                    objAdd.Name = reader["Name"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Futoshiki objAdd = new Futoshiki();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Futoshiki getFutoshikiWithID(Futoshiki obj)
        {
            Futoshiki objR = new Futoshiki();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getFutoshikiWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FTGameID", obj.FTGameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.FTGameID = Convert.ToInt32(reader["FTGameID"]);
                    objR.RankID = Convert.ToInt32(reader["RankID"]);
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objR.WIn = Convert.ToInt32(reader["WIn"]);
                    objR.Loose = Convert.ToInt32(reader["Loose"]);
                    objR.Draw = Convert.ToInt32(reader["Draw"]);
                    objR.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
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

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setFutoshiki(Futoshiki obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setFutoshiki", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FTGameID", obj.FTGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@WIn", obj.WIn);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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
        public Response updateFutoshiki(Futoshiki obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateFutoshiki", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FTGameID", obj.FTGameID);
                cmd.Parameters.AddWithValue("@RankID", obj.RankID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@WIn", obj.WIn);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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


        #region Suduko
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<Suduko> getSuduko()
        {
            List<Suduko> objRList = new List<Suduko>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSuduko", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Suduko objAdd = new Suduko();
                    objAdd.SDGameID = Convert.ToInt32(reader["SDGameID"]);
                    objAdd.KhID = Convert.ToInt32(reader["KhID"]);
                    objAdd.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objAdd.Win = Convert.ToInt32(reader["Win"]);
                    objAdd.Loose = Convert.ToInt32(reader["Loose"]);
                    objAdd.Draw = Convert.ToInt32(reader["Draw"]);
                    objAdd.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
                    objAdd.Name = reader["Name"].ToString();
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Suduko objAdd = new Suduko();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Suduko getSudukoWithID(Suduko obj)
        {
            Suduko objR = new Suduko();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getSudukoWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SDGameID", obj.SDGameID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.SDGameID = Convert.ToInt32(reader["SDGameID"]);
                    objR.KhID = Convert.ToInt32(reader["KhID"]);
                    objR.Ratting = Convert.ToInt32(reader["Ratting"]);
                    objR.Win = Convert.ToInt32(reader["Win"]);
                    objR.Loose = Convert.ToInt32(reader["Loose"]);
                    objR.Draw = Convert.ToInt32(reader["Draw"]);
                    objR.LastFiveMatchRatting = Convert.ToInt32(reader["LastFiveMatchRatting"]);
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

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public Response setSuduko(Suduko obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setSuduko", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SDGameID", obj.SDGameID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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
        public Response updateSuduko(Suduko obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateSuduko", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SDGameID", obj.SDGameID);
                cmd.Parameters.AddWithValue("@KhID", obj.KhID);
                cmd.Parameters.AddWithValue("@Ratting", obj.Ratting);
                cmd.Parameters.AddWithValue("@Win", obj.Win);
                cmd.Parameters.AddWithValue("@Loose", obj.Loose);
                cmd.Parameters.AddWithValue("@Draw", obj.Draw);
                cmd.Parameters.AddWithValue("@LastFiveMatchRatting", obj.LastFiveMatchRatting);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
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


        #region ShikkhanobishCoin
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public List<ShikkhanobishCoin> getShikkhanobishCoin()
        {
            List<ShikkhanobishCoin> objRList = new List<ShikkhanobishCoin>();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getShikkhanobishCoin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShikkhanobishCoin objAdd = new ShikkhanobishCoin();
                    objAdd.UserID = Convert.ToInt32(reader["UserID"]);
                    objAdd.Coin = Convert.ToInt32(reader["Coin"]);
                    objRList.Add(objAdd);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ShikkhanobishCoin objAdd = new ShikkhanobishCoin();
                objAdd.Response = ex.Message;
                objRList.Add(objAdd);
            }
            return objRList;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public ShikkhanobishCoin getShikkhanobishCoinWithID(ShikkhanobishCoin obj)
        {
            ShikkhanobishCoin objR = new ShikkhanobishCoin();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("getShikkhanobishCoinWithID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objR.UserID = Convert.ToInt32(reader["UserID"]);
                    objR.Coin = Convert.ToInt32(reader["Coin"]);

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
        public Response setShikkhanobishCoin(ShikkhanobishCoin obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("setShikkhanobishCoin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@Coin", obj.Coin);
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
        public Response updateShikkhanobishCoin(ShikkhanobishCoin obj)
        {
            Response response = new Response();
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("updateShikkhanobishCoin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
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