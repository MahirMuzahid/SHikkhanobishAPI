using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class activeStatusTable
    {
        public int userID  { get; set; }
        public int activeStatus { get; set; }
        public int type { get; set; }
        public string Response { get; set; }
    }
}