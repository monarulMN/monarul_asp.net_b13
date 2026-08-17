using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IProductImageRepository ProductImageRepository { get; private set; }
        public ISizeRepository SizeRepository { get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext dbContext, 
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductImageRepository productImageRepository,
            ISizeRepository sizeRepository)
            : base(dbContext)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            ProductImageRepository = productImageRepository;
            SizeRepository = sizeRepository;
        }

    }
}
