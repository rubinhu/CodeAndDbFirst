using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class AppParam
    {
        public string Group { get; set; }
        public decimal? Code { get; set; }
        public string Description { get; set; }
        public string Lang { get; set; }
    }
}
