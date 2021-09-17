using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class Employee
    {
        public string Emplid { get; set; }
        public string Cname { get; set; }
        public string Ename { get; set; }
        public string Plant { get; set; }
        public string Mail { get; set; }
        public string Deptid { get; set; }
        public string UpperDept { get; set; }
        public string EmplCategory { get; set; }
        public string Supervisor { get; set; }
        public decimal? OfficerLevel { get; set; }
        public string Cardid { get; set; }
        public string Proxy { get; set; }
        public string L1 { get; set; }
        public string Tdate { get; set; }
        public string Treason { get; set; }
        public DateTime? Udate { get; set; }
        public string Userid { get; set; }
        public string Company { get; set; }
        public string Deptn { get; set; }
        public DateTime? Hdate { get; set; }
        public string Calendar { get; set; }
        public string Atvalid { get; set; }
        public string Descrshort { get; set; }
        public decimal? Otlimit { get; set; }
        public string Otvalid { get; set; }
        public string Nxtapprove { get; set; }
        public DateTime? RehireDt { get; set; }
        public string ProxyTime { get; set; }
        public DateTime? OtStime { get; set; }
        public DateTime? OtEtime { get; set; }
        public char? Adult { get; set; }
        public string Location { get; set; }
        public string Tcode { get; set; }
        public string Gradeidentifier { get; set; }
        public string Sex { get; set; }
        public DateTime? DeptEntryDt { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime? Ptdate { get; set; }
        public string Ptype { get; set; }
        public string SiteIdA { get; set; }
        public string UinSgp { get; set; }
    }
}
