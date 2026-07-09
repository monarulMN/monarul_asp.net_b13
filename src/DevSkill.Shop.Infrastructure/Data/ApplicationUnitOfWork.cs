using DevSkill.Shop.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ITeamMemberRepository TeamMemberRepository { get; private set; }

        public ICategoryRepository CategoryRepository {  get; private set; }

        public IProductRepository ProductRepository {  get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext dbContext, 
            ITeamMemberRepository teamMemberRepository,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
            : base(dbContext)
        {
            TeamMemberRepository = teamMemberRepository;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }
    }
}
