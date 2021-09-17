using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxMenu
    {
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Type { get; set; }
        public string Apid { get; set; }
        public int? Seq { get; set; }
    }
}
