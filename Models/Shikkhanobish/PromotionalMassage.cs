using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class PromotionalMassage
    {
        public string imageSrc { get; set; }
        public string text { get; set; }
        public int msgType { get; set; }
        public string userType { get; set; }
        public string playstoreAppLink { get; set; } = "https://play.google.com/store/apps/details?id=com.pathao.user&hl=en";
        public string Response { get; set; }
    }
}