using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class ReferralTable
    {
        public string referralID { get; set; }
        public int studentID { get; set; }
        public int referredStudentID { get; set; }
        public string referralDate { get; set; }
        public string Response { get; set; }

    }
}