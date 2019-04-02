using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid ShoppingCardId { get; set; }
        public virtual ShoppingCart ShoppingCard { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public void CreateShoppingCard()
        {
            ShoppingCard = new ShoppingCart
            {
                Id = new Guid(),
                Customer = this,
                CustomerId = Id,
            };
            ShoppingCardId = ShoppingCard.Id;
        }
    }
}
