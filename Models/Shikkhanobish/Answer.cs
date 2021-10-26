using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class Answer
    {
        public string answerID { get; set; }
        public string name { get; set; }
        public string answer { get; set; }
        public string answerDate { get; set; }
        public int userID { get; set; }
        public int userType { get; set; }
        public string imgSrc { get; set; }
        public int review { get; set; }
        public string postID { get; set; }
        public string Response { get; set; }
    }
}