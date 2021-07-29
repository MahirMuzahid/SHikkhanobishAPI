using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class PremiumStudent
    {
        public int studentID { get; set; }
        public int buyingAmount { get; set; }
        public string maxNumberofFavouriteTeacher { get; set; }
        public string Response { get; set; }
    }
}