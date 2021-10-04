using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class TeacherActivityStatus
    {
        public int teacherID { get; set; }
        public int activityStatus { get; set; } 
        public string Response { get; set; }
    }
}