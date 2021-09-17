using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxLotteryWinner
    {
        public decimal LotteryId { get; set; }
        public string Award { get; set; }
        public string AwardDes { get; set; }
        public string Id { get; set; }
        public string Uuser { get; set; }
        public DateTime? Udate { get; set; }

        public virtual WxBdLottery Lottery { get; set; }
    }
}
