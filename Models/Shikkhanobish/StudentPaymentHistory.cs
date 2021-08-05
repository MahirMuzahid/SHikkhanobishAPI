using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class StudentPaymentHistory
    {
        public int studentID { get; set; }
        public string paymentID { get; set; }
        public string date { get; set; }
        public string trxID { get; set; }
        public int amountTaka { get; set; }
        public int amountCoin { get; set; }
        public string medium { get; set; }
        public int isVoucherUsed { get; set; }
        public string cardID { get; set; }
        public int voucherID { get; set; }
        public string name { get; set; }
        public string Response { get; set; }
    }
}