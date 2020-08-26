using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHikkhanobishAPI.Models
{
    public class AllSubAndTeacherReagister
    {
        public int TeacherID { get; set; }
        public string InstitutionID { get; set; }
        public int LSBAN01 { get; set; }
        public int LSBAN02 { get; set; }
        public int LSENG01 { get; set; }
        public int LSENG02 { get; set; }
        public int LSICT { get; set; }
        public int LSBGS { get; set; }
        public int LSAGR { get; set; }
        public int LSCRE { get; set; }
        public int LSGSC { get; set; }
        public int LSMATH { get; set; }
        public int SBAN01 { get; set; }
        public int SBAN02 { get; set; }
        public int SENG01 { get; set; }
        public int SENG02 { get; set; }
        public int SGMATH { get; set; }
        public int SREL { get; set; }
        public int SICT { get; set; }
        public int SGSC { get; set; }
        public int SPHY { get; set; }
        public int SCHE { get; set; }
        public int SBIO { get; set; }
        public int SHMATH { get; set; }
        public int SECO { get; set; }
        public int SACC { get; set; }
        public int SFIN { get; set; }
        public int SAGR { get; set; }
        public int SHOM { get; set; }
        public int SBENT { get; set; }
        public int SCRE { get; set; }
        public int SBGS { get; set; }
        public int SGEO { get; set; }
        public int SPEDU { get; set; }
        public int HSBAN01 { get; set; }
        public int HSBAN02 { get; set; }
        public int HSENG01 { get; set; }
        public int HSENG02 { get; set; }
        public int HSPHY01 { get; set; }
        public int HSPHY02 { get; set; }
        public int HSCHE01 { get; set; }
        public int HSCHE02 { get; set; }
        public int HSBIO01 { get; set; }
        public int HSBIO02 { get; set; }
        public int HSMATH01 { get; set; }
        public int HSMATH02 { get; set; }
        public int HSICT { get; set; }
        public int HSSTAT { get; set; }
        public int HSLOG { get; set; }
        public int HSFOOD { get; set; }
        public int HSFIN { get; set; }
        public int HSACC { get; set; }
        public int HSECO { get; set; }
        /// <summary>
        /// Teacher Info
        /// </summary>
        public string InstituitionID { get; set; }
        public int IsActive { get; set; }
        public int IsOnTuition { get; set; }
        public int Five_Star { get; set; }
        public int Four_Star { get; set; }
        public int Three_Star { get; set; }
        public int Two_Star { get; set; }
        public int One_Star { get; set; }

        public int Total_Min { get; set; }
        public int Number_Of_Tution { get; set; }
        public int Tuition_Point { get; set; }
        public string Teacher_Rank { get; set; }
        public string TeacherName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public string InstitutionName { get; set; }
        public int RechargedAmount { get; set; }
        public string response { get; set; }
    }
}