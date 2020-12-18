using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Sillicon
{
    public class IssueVoucher
    {
        public int IssueVoucherID { get; set; }
        public string IssueVoucherDate { get; set; }
        public string itemNumber { get; set; }
        public string description { get; set; }
        public int IssueQuantity { get; set; }
        public int wareHouseID { get; set; }
        public string workOrderNo { get; set; }
        public string Condition { get; set; }
        public string contructorName { get; set; }
        public string Response { get; set; }
        public string requisition { get; set; }
        public int IsPrinted { get; set; }
        public string wareHouseName { get; set; }
    }
}