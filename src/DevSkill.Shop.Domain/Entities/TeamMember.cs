using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Entities
{
    public class TeamMember : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
