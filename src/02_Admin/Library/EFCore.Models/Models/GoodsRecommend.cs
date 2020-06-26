using System;
using System.Collections.Generic;

namespace EFCore.Models.Models
{
    public partial class GoodsRecommend
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? SortId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
