using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Medhabi
{
    public class PlayerHistory
    {
        public int matchID { get; set; }
        public string matchStatus { get; set; }
        public int q1 { get; set; }
        public int q2 { get; set; }
        public int q3 { get; set; }
        public int q4 { get; set; }
        public int q5 { get; set; }
        public int playerID { get; set; }
        public int whatToDO { get; set; }
        public string response { get; set; }
        public int status { get; set; }


    }
}