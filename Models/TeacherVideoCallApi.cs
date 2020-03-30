using OpenTokSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class TeacherVideoCallApi
    {
        public TeacherVideoCallApi()
        {
            APIKey = 46485492;
            API_SECRET = "c255c95670bc11eecaf5950baf375d7478f74665";
        }
        public int TeacherID { get; set; }
        public int APIKey { get; set; }
        public string API_SECRET { get; set; }
        public string SessionID { get; set; }
        public string Token { get; set; }

        public string Response { get; set; }

        public void CreateSessionAndToken()
        {
            
            // Set the following constants with the API key and API secret
            // that you receive when you sign up to use the OpenTok API:
            OpenTok opentok = new OpenTok(APIKey, API_SECRET);

            //Generate a basic session. Or you could use an existing session ID.
            SessionID = opentok.CreateSession().Id;

            // Generate a token. Use the Role value appropriate for the user.
            Token = opentok.GenerateToken(SessionID, Role.PUBLISHER);
        }

    }
}