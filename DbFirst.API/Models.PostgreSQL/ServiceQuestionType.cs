using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class ServiceQuestionType
    {
        public string Id { get; set; }
        public string Desc { get; set; }
        public string Site { get; set; }
        public string Isvalid { get; set; }
        public string Uuser { get; set; }
        public DateTime? Udate { get; set; }
        public string UnitId { get; set; }
    }
}
