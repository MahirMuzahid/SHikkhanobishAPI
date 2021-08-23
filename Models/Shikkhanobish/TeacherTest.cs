using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class TeacherTest
    {
        public int questionID { get; set; }
        public string question { get; set; }
        public string opOne { get; set; }
        public string opTwo { get; set; }
        public string opThree { get; set; }
        public string opFour { get; set; }
        public int rightAns { get; set; }
        public string Response { get; set; }
    }
}