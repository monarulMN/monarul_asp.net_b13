using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class Color : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; } 
            = new List<ProductColor>();
    }
}
