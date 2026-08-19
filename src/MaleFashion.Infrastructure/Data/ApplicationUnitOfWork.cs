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
        public IProductSizeRepository ProductSizeRepository { get; private set; }
        public IColorRepository ColorRepository { get; private set; }
        public IProductColorRepository ProductColorRepository { get; private set; }
        public ICartRepository CartRepository { get; private set; }
        public ICartItemRepository CartItemRepository { get; private set; }


        public ApplicationUnitOfWork(ApplicationDbContext dbContext,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductImageRepository productImageRepository,
            ISizeRepository sizeRepository,
            IProductSizeRepository productSizeRepository,
            IColorRepository colorRepository,
            IProductColorRepository prodcutColorRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository)
            : base(dbContext)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            ProductImageRepository = productImageRepository;
            SizeRepository = sizeRepository;
            ProductSizeRepository = productSizeRepository;
            ColorRepository = colorRepository;
            ProductColorRepository = prodcutColorRepository;
            CartRepository = cartRepository;
            CartItemRepository = cartItemRepository;
        }

    }
}
