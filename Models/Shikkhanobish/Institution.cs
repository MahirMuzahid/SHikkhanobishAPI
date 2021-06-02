using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class Institution
    {
        public int institutionID { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public int tuitionRequest { get; set; }
        public double avgRatting { get; set; }
        public int indexNo { get; set; }
        public string Response { get; set; }
    }
}