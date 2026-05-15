using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IMemberRepository MemberRepository { get; }
        public ITeamRepository TeamRepository { get; }
    }
}
