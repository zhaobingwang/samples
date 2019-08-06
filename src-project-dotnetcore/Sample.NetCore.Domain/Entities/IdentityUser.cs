using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.NetCore.Domain.Entities
{
    public class IdentityUser : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public byte Status { get; set; }
    }
}
