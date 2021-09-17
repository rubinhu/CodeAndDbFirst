using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class PostSuitedList
    {
        public string Emplid { get; set; }
        public string Cname { get; set; }
        public string Deptid { get; set; }
        public string Descr { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Phone { get; set; }
        public string UinSgp { get; set; }
        public string Submitter { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
