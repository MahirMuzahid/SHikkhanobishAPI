using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class ResetInfo
    {
        public string Username { get; set; }
        public int IsTeacherorStudent { get; set; }
        public int IsPasswordOrUsername { get; set; }
        public string NewpassOrUsername { get; set; }

        public string Response { get; set; }

    }
}