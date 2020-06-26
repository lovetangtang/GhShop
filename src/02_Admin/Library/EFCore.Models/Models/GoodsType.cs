using System;
using System.Collections.Generic;

namespace EFCore.Models.Models
{
    public partial class GoodsType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abridge { get; set; }
        public int? Rank { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
