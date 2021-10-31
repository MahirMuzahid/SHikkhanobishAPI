using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class TagStudentConnector
    {
        public int tagStudentID { get; set; }
        public int studentID { get; set; }
        public int tagID { get; set; }
        public string Response { get; set; }
    }
}