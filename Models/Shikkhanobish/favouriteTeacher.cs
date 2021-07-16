using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class favouriteTeacher
    {
        public int teacherID { get; set; }
        public int studentID { get; set; }
        public string teacherName { get; set; }
        public string studentName { get; set; }
        public int teacherTotalTuition { get; set; }
        public int subjectID { get; set; }
        public double teacherRatting { get; set; }
        public string Response { get; set; }
    }
}