﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class TuitionHistoryStudent
    {
        public int StundentID { get; set; }
        public int TutionTeacherID { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int Ratting { get; set; }
        public string Response { get; set; }
        public string Teacher_Name { get; set; }
    }
}