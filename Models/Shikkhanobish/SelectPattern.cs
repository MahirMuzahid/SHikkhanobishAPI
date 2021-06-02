using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class SelectPattern
    {
        public int slPatternID { get; set; }
        public int firstIndex { get; set; }
        public int secondIndex { get; set; }
        public int thirdindex { get; set; }
        public int forthindex { get; set; }
        public string Response { get; set; }
    }
}