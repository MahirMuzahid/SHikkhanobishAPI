using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class VoucherAndOffer
    {
        public string Code { get; set; }
        public int StudentID { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int IsPremium { get; set; }
        public string Response { get; set; }
              
    }
}