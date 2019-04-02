using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public User Customer { get; set; }
    }
}
