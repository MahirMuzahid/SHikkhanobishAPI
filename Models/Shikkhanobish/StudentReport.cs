using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class StudentReport
    {
        public int studentReportID { get; set; }
        public int reportType { get; set; }
        public string description { get; set; }
        public int studentID { get; set; }
        public string teacherName { get; set; }
        public int teacherID { get; set; }
        public string ReportTypeText { get; set; }
        public string date { get; set; }
        public string Response { get; set; }
    }
}