using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class PerMinCallResponse
    {
        public string Massage { get; set; }
        public int cost { get; set; }
        public double earned { get; set; }
        public int Status { get; set; }
    }
}