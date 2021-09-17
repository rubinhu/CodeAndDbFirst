using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class AccountGuest
    {
        public string Accountid { get; set; }
        public string Password { get; set; }
        public string Isvalid { get; set; }
        public string Site { get; set; }
    }
}
