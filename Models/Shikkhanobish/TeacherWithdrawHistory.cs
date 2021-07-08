using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class TeacherWithdrawHistory
    {
        public int withdrawID { get; set; }
        public string date { get; set; }
        public string trxID { get; set; }
        public int amountTaka { get; set; }
        public string medium { get; set; }
        public int teacherID { get; set; }
        public string phoneNumber { get; set; }
        public int status { get; set; }
        public string response { get; set; }
    }
}