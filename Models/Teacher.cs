﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string InstituitionID { get; set; }
        public int StudentID { get; set; }
        public int IsActive { get; set; }
        public int IsOnTuition { get; set; }
        public int Five_Star { get; set; }
        public int Four_Star { get; set; }
        public int Three_Star { get; set; }
        public int Two_Star { get; set; }
        public int One_Star { get; set; }

        public int Total_Min { get; set; }
        public int Number_Of_Tution { get; set; }
        public int Tuition_Point { get; set; }
        public string Teacher_Rank { get; set; }
        public string TeacherName { get; set; }
        public string response { get; set; }
    }
}