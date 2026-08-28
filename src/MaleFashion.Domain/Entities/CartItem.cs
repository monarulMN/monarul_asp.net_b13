using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class CartItem : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public Guid? SizeId { get; set; }
        public Size Size { get; set; }

        public Guid? ColorId { get; set; }
        public Color Color { get; set; }
    }
}
