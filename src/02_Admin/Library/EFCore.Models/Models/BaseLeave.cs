using System;
using System.Collections.Generic;

namespace EFCore.Models.Models
{
    public partial class BaseLeave
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Cdate { get; set; }
    }
}
