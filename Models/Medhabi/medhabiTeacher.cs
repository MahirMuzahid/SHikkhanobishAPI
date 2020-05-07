using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Medhabi
{
    public class medhabiTeacher
    {
        public int teacherID { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public int amount { get; set; }
        public int posted_question { get; set; }
        public string rank { get; set; }
        public string response { get; set; }
        public int stetus { get; set; }
    }
}