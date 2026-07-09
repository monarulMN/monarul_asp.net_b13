using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Entities
{
    public class ProductImage : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public Guid Serial { get; set; }
        public string ImageName { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
