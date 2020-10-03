using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class OfferAndVoucherSource
    {
        public string code { get; set; }
        public string  type { get; set; }
        public int limit { get; set; }
        public int amount { get; set; }
        public string imageSource { get; set; }
        public string  response { get; set; }
        public int voucherID { get; set; }
    }
}