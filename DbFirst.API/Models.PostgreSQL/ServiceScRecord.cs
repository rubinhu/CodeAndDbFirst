using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class ServiceScRecord
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string UploadMethod { get; set; }
        public string UploadType { get; set; }
        public string Emplid { get; set; }
        public string Cname { get; set; }
        public DateTime? HireDate { get; set; }
        public string PhoneNumber { get; set; }
        public string IsApplyQuit { get; set; }
        public string UploadReason { get; set; }
        public string IdlStaffNotes { get; set; }
        public string BankCategory { get; set; }
        public string BankNumber { get; set; }
        public DateTime UploadTime { get; set; }
        public string ImgUrl { get; set; }
    }
}
