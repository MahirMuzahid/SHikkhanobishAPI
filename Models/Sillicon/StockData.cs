using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Sillicon
{
    public class StockData
    {
        public int wareHouseID { get; set; }
        public int itemID { get; set; }
        public string itemNO { get; set; }
        public int currentBalance { get; set; }
        public string unit { get; set; }
        public string Response { get; set; }
    }
}