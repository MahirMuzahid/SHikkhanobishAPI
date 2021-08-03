using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class CallBackPayment
    {
        public string pg_service_charge_bdt { get; set; }
        public string pg_service_charge_usd { get; set; }
        public string pg_card_bank_name { get; set; }
        public string pg_card_bank_country { get; set; }
        public string card_number { get; set; }
        public string card_holder { get; set; }
        public string cus_phone { get; set; }
        public string desc { get; set; }
        public string success_url { get; set; }
        public string fail_url { get; set; }
        public string cus_name { get; set; }
        public string cus_email { get; set; }
        public string currency_merchant { get; set; }
        public string convertion_rate { get; set; }
        public string ip_address { get; set; }
        public string other_currency { get; set; }
        public string pay_status { get; set; }
        public string pg_txnid { get; set; }
        public string epw_txnid { get; set; }
        public string mer_txnid { get; set; }
        public string store_id { get; set; }
        public string merchant_id { get; set; }
        public string currency { get; set; }
        public string store_amount { get; set; }
        public string pay_time { get; set; }
        public string amount { get; set; }
        public string bank_txn { get; set; }
        public string card_type { get; set; }
        public string reason { get; set; }
        public string pg_card_risklevel { get; set; }
        public string pg_error_code_details { get; set; }
        public string opt_a { get; set; }
        public string opt_b { get; set; }
        public string opt_c { get; set; }
        public string opt_d { get; set; }

    }
}