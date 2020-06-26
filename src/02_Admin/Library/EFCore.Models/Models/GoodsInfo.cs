using System;
using System.Collections.Generic;

namespace EFCore.Models.Models
{
    public partial class GoodsInfo
    {
        public int Id { get; set; }
        public string GoodsName { get; set; }
        public string Free { get; set; }
        public string Send { get; set; }
        public string Hotline { get; set; }
        public decimal? TradePrice { get; set; }
        public decimal? MarketPrice { get; set; }
        public string Heat { get; set; }
        public string Remark { get; set; }
        public string Introduce { get; set; }
    }
}
