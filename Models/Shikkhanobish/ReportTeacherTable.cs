using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class ReportTeacherTable
    {
        public int reportID { get; set; }
        public int studentID { get; set; }
        public int teacherID { get; set; }
        public int reportIndex { get; set; }
        public string description { get; set; }

        public string Response { get; set; }
    }
}