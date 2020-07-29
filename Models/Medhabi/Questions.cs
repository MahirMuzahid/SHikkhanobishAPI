using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Medhabi
{
    public class Questions
    {
        public string question_code { get; set; }
        public string question { get; set; }
        public string first_choice { get; set; }
        public string second_choice { get; set; }
        public string third_choice { get; set; }
        public string forth_choice { get; set; }
        public int right_answer { get; set; }
        public int questionID { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public string response { get; set; }
        public int stetus { get; set; }
        public int teacherID { get; set; }
    }
}