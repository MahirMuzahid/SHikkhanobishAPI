using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Sillicon
{
    public class ReturnVoucher
    {
        public string returnDate { get; set; }
        public int retID { get; set; }
        public string ret_warehouse { get; set; }
        public int wareHouseID { get; set; }
        public string cause { get; set; }
        public string ret_type { get; set; }
        public string condition { get; set; }
        public string contructor { get; set; }
        public int isPrinted { get; set; }
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public int quentity { get; set; }
        public string workOrderNo { get; set; }
        public string Response { get; set; }

    }
}