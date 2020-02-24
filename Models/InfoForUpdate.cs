using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class InfoForUpdate
    {
        public int TeacherID { get; set; }
        public int IsActive { get; set; }
        public int IsOnTuition { get; set; }
        public int StudentID { get; set; }
        public int Rating { get; set; }
        public int InAppMin { get; set; }
        public int Tuition_Point { get; set; }
        public string Teacher_Rank { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string SubjectName { get; set; }
        public int Class { get; set; }
        public int IsPenidng { get; set; }
        public string Teacher_Name { get; set; }
        public string Student_Name { get; set; }
    }
}