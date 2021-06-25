using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class SendSms
    {
        public string msg { get; set; }
        public string number { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string user { get; set; }
        public string respose { get; set; }
    }
}