using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxErrorlog
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime? Udate { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string PropsTest { get; set; }
        public string MachineName { get; set; }
    }
}
