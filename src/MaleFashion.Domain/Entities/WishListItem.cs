using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class WishListItem : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid WishListId { get; set; }
        public WishList WishList { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
