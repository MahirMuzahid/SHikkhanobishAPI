using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class ShikkhanobishUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Response { get ; set ;}
}
}