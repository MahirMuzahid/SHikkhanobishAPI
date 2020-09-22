using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class TransferPoint
    {
        public float StudentCost { get; set; }
        public float TeacherEarn { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }

    }
}