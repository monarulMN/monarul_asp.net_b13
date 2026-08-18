using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class ProductSize : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid SizeId { get; set; }
        public Size Size { get; set; }

        public int StockQuantity { get; set; }
    }
}
