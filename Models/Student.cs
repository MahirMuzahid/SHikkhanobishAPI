using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class Student
    {
        public int StundentID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string InstitutionName { get; set; }
        public int RechargedAmount { get; set; }
        public int IsPending { get; set; }
        public string Response { get; set; }
        public int TotalTuitionTIme { get; set; }
        public int TotalTeacherCount { get; set; }
        public int ParentCode { get; set; }
        public float AvarageRating { get; set; }
    }
}