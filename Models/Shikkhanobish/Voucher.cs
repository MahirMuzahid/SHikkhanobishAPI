using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class Voucher
    {
        public int voucherID { get; set; }
        public string name { get; set; }
        public int amountTaka { get; set; }
        public int getAmount { get; set; }
        public int type { get; set; }
        public string validFrom { get; set; }
        public string validTo { get; set; }
        public string voucherImageSrc { get; set; }
        public int canUse { get; set; }
        public string Response { get; set; }
    }
}