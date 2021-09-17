using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WxBdLottery
    {
        public WxBdLottery()
        {
            WxLotteryWinners = new HashSet<WxLotteryWinner>();
        }

        public decimal LotteryId { get; set; }
        public string Emplid { get; set; }
        public string Plant { get; set; }
        public string Cname { get; set; }
        public string Deptid { get; set; }

        public virtual ICollection<WxLotteryWinner> WxLotteryWinners { get; set; }
    }
}
