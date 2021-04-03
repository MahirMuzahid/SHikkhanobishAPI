using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class Checkers
    {
        public int CHGameID { get; set; }
        public int RankID { get; set; }
        public int KhID { get; set; }
        public int Ratting { get; set; }
        public int Win { get; set; }
        public int Loose { get; set; }
        public int Draw { get; set; }
        public int LastFiveMatchRatting { get; set; }
        public string Name { get; set; }
        public string Response { get; set; }
    }
}