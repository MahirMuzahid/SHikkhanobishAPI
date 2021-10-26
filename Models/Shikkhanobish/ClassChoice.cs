using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class ClassChoice
    {
        public int studentID { get; set; }
        public int institutionID { get; set; }
        public int classID { get; set; }
        public string Response { get; set; }
    }
}