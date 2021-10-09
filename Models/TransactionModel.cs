using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class TransactionModel
    {
        public string store_id { get; set; } = "shikkhanobish";
        public string signature_key { get; set; } = "0cbb2e487f5c556097cc302139ce5500";
        public string amount { get; set; }
        public string currency { get; set; } = "BDT";
        public string tran_id { get; set; }
        public string cus_name { get; set; }
        public string cus_email { get; set; } = "";
        public string cus_add1 { get; set; } = "";
        public string cus_add2 { get; set; } = "Bashundhara R/A, Dhaka";
        public string cus_city { get; set; } = "";
        public string cus_state { get; set; } = "";
        public string cus_postcode { get; set; } = "";
        public string cus_country { get; set; } = "";
        public string cus_phone { get; set; }
        public string cus_fax { get; set; } = "";
        public string ship_name { get; set; } = "";
        public string ship_add1 { get; set; } = "";
        public string ship_add2 { get; set; } = "";
        public string ship_city { get; set; } = "";
        public string ship_state { get; set; } = "";
        public string ship_postcode { get; set; } = "";
        public string ship_country { get; set; } = "";
        public string desc { get; set; } = "Payment";
        public string amount_processingfee_ratio { get; set; } = "0";
        public string amount_processingfee { get; set; } = "0";
        public string amount_vatratio { get; set; } = "0";
        public string amount_vat { get; set; } = "0";
        public string amount_taxratio { get; set; } = "0";
        public string amount_tax { get; set; } = "0";
        public string success_url { get; set; }
        public string fail_url { get; set; }
        public string cancel_url { get; set; }
        public string opt_a { get; set; }
        public string opt_b { get; set; } = "";
        public string opt_c { get; set; } = "";
        public string opt_d { get; set; } = "";
        public string type { get; set; } = "json";
    }
}