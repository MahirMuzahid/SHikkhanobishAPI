using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class PerMinPassModel
    {
        public int studentID { get; set; }
        public int teacherID { get; set; }
        public int time { get; set; }
        public string sessionID { get; set; }
        public string firstChoiceID { get; set; }
        public string secondChoiceID { get; set; }
        public string thirdChoiceID { get; set; }
        public string forthChoiceID { get; set; }
        public string firstChoiceName { get; set; }
        public string secondChoiceName { get; set; }
        public string thirdChoiceName { get; set; }
        public string forthChoiceName { get; set; }
        public string Response { get; set; }
    }
}