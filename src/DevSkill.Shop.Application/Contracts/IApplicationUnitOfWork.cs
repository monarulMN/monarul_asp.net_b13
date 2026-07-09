using DevSkill.Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public ITeamMemberRepository TeamMemberRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
    }
}
