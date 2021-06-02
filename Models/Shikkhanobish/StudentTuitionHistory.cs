using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class StudentTuitionHistory
    {
        public int studentID { get; set; }
        public int tuitionID { get; set; }
        public string time { get; set; }
        public int teacherID { get; set; }
        public int cost { get; set; }
        public int ratting { get; set; }
        public string firstChoiceID { get; set; }
        public string secondChoiceID { get; set; }
        public string thirdChoiceID { get; set; }
        public string forthChoiceID { get; set; }
        public string Response { get; set; }
    }
}