﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class WalletHistoryStudent
    {
        public int StudentID { get; set; }
        public int RechargedAmount { get; set; }
        public int Phonenumber { get; set; }
        public string TrxID { get; set; }
        public string Date { get; set; }
        public int IsPending { get; set; }
        public string Response { get; set; }
    }
}