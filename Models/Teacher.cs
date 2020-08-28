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

        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string InstitutionName { get; set; }
        public int RechargedAmount { get; set; }
        public int isFounder { get; set; }
        public string response { get; set; }
    }
}