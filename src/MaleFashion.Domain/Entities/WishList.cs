using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class WishList : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<WishListItem> WishlistItems { get; set; }
            = new List<WishListItem>();
    }
}
