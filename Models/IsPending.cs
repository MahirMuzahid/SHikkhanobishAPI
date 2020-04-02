﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class IsPending
    {
        public int StudentID { get; set; }
        public string TeacherName { get; set; }
        public int TeacherID { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public int Time { get; set; }
        public int Cost { get; set; }               
        public string Response { get; set; }
    }
}