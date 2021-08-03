using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class requestPayment
    {
        public string name { get; set; }
        public int amount { get; set; }
        public string phonenumber { get; set; }
    }
}