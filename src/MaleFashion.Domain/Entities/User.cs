using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class User : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public Cart? Cart { get; set; }

        public WishList? WishList { get; set; }

        public ICollection<Order> Orders { get; set; }
            = new List<Order>();

        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();
    }
}
