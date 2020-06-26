using Kogel.Dapper.Extension.Attributes;
using System;
using System.Collections.Generic;

namespace Web.Models
{
    [Display(Rename = "BaseUser")]
    public  class CmNumberInfo1
    {
        [Identity]
        public int Id { get; set; }
        public int RuleId { get; set; }
        public int NumberId { get; set; }
        public int TypeId { get; set; }
    }
}
