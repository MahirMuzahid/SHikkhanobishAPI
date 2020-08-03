using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Medhabi
{
    public class medhabiStudent
    {
        public int studentID { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public int amount { get; set; }
        public int point { get; set; }
        public string rank { get; set; }
        public int total_question_answered { get; set; }
        public int total_right_answer { get; set; }
        public string response { get; set; }
        public int stetus { get; set; }

    }
}