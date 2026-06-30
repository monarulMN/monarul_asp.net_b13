using DevSkill.Shop.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ITeamMemberRepository TeamMemberRepository { get; private set; }
        public ApplicationUnitOfWork(ApplicationDbContext dbContext, 
            ITeamMemberRepository teamMemberRepository)
            : base(dbContext)
        {
            TeamMemberRepository = teamMemberRepository;
        }
    }
}
