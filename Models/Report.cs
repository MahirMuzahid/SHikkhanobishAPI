using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class Report
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string ReportType { get; set; }
        public string ReportText { get; set; }

        
    }
}