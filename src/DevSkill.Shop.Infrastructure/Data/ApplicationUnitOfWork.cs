using DevSkill.Shop.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IMemberRepository MemberRepository { get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext dbContext, IMemberRepository memberRepository)
            : base(dbContext)
        {
            MemberRepository = memberRepository;
        }
    }
}
