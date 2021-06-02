using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class VoucherHistory
    {
        public int studentID { get; set; }
        public int voucherHistoryID { get; set; }
        public int paymentID { get; set; }
        public string Response { get; set; }
    }
}