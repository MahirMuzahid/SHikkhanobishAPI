using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class DashBoardUser
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string Response { get; set; }

    }
}