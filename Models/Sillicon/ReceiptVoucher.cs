using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Sillicon
{
    public class ReceiptVoucher
    {
        public int RRVoucherID { get; set; }
        public string RRDate { get; set; }
        public string condition { get; set; }
        public string warehouse { get; set; }
        public string supplier { get; set; }
        public string contructor { get; set; }
        public string deliveredTo { get; set; }
        public string checkedby { get; set; }
        public int allocNumber { get; set; }
        public string alolocDate { get; set; }
        public string wordOrderNo { get; set; }
        public string challan { get; set; }
        public int isPrinted { get; set; }
        public string itemNumber { get; set; }
        public string description { get; set; }
        public int RCVQuantity { get; set; }
        public int wareHouseID { get; set; }
        public string Response { get; set; }
    }
}