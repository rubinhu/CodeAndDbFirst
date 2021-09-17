using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxUselog
    {
        public string Empno { get; set; }
        public string Site { get; set; }
        public string Api { get; set; }
        public DateTime? Usetime { get; set; }
        public string System { get; set; }
        public string Domain { get; set; }
        public string Requestip { get; set; }
        public string Responsetime { get; set; }
    }
}
