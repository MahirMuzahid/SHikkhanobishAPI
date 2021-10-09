using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class TeacherQuestionHistory
    {
        public int tqID { get; set; }
        public int teacherID { get; set; }
        public int questionID { get; set; }
        public string review { get; set; }
        public string Response { get; set; }
    }
}