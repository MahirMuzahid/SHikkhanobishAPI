using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Medhabi
{
    public class MatchMaking
    {
        public int firstPlayerID { get; set; }
        public int secondPlayerID { get; set; }
        public string matchID { get; set; }
        public int firstQuestionID { get; set; }
        public int secondQuestionID { get; set; }
        public int thirdQuestionID { get; set; }
        public int forthQuestionID { get; set; }
        public int fifthQuestionID { get; set; }
        public string response { get; set; }
        public int stetus { get; set; }
    }
}