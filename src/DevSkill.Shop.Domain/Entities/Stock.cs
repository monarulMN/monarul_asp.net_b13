using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Entities
{
    public class Stock : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public Guid Quantity { get; set; }
        public Guid LowStockQuantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
