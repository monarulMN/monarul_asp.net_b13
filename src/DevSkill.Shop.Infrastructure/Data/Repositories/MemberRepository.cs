using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
