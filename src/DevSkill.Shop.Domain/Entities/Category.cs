using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Entities
{
    public class Category : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public string ImageName { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
