using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class KhelaGhorUser
    {
        public int KhID { get; set; }
        public int UserID { get; set; }
        public int TotalGame { get; set; }       
        public int TotalWin { get; set; }
        public int TotalLoose { get; set; }
        public int TotalDraw { get; set; }
        public string Response { get; set; }
    }
}