using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class VideoApiInfo
    {
        public int apiKey { get; set; }
        public string SessionID { get; set; }
        public string token { get; set; }
        public string Response { get; set; }
    }
}