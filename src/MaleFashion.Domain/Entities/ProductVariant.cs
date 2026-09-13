using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class ProductVariant : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public int StcokQuantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
