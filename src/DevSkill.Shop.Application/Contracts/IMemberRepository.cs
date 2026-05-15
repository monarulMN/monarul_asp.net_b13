using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IMemberRepository : IRepository<Member, Guid>
    {
    }
}
