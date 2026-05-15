using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Entities
{
    public class Team : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
