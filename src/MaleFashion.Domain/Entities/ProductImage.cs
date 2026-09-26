using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class ProductImage : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public int DisplayOrder { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
