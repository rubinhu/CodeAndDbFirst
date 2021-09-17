using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxUserprofile
    {
        public string UnionId { get; set; }
        public string AvatarUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string NickName { get; set; }
        public string OpenId { get; set; }
        public string Province { get; set; }
        public string Uuser { get; set; }
        public DateTime? Udate { get; set; }
    }
}
