using System;
using System.Collections.Generic;

namespace EFCore.Models.Models
{
    public partial class BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Card { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
