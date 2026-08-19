using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class Cart : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();
    }
}
