using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class ProductColor : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        public int StockQuantity { get; set; }
    }
}
