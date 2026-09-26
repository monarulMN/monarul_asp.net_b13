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
        public ISqlUtility SqlUtility { get; private set; }


        //public ICartRepository CartRepository { get; private set; }
        //public ICartItemRepository CartItemRepository { get; private set; }
        //public IOrderRepository OrderRepository { get; private set; }
        //public IOrderItemRepository OrderItemRepository { get; private set; }
        //public IWishListRepository WishListRepository { get; private set; }
        //public IWishListItemRepository WishListItemRepository { get; private set; }
        //public IReviewRepository ReviewRepository { get; private set; }



        public ApplicationUnitOfWork(ApplicationDbContext dbContext,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductImageRepository productImageRepository

            //ICartRepository cartRepository,
            //ICartItemRepository cartItemRepository,
            //IOrderRepository orderRepository,
            //IOrderItemRepository orderItemRepository,
            //IWishListRepository wishListRepository,
            //IWishListItemRepository wishListItemRepository,
            //IReviewRepository reviewRepository
            )
            : base(dbContext)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            ProductImageRepository = productImageRepository;
            SqlUtility = new SqlUtility(dbContext.Database.GetDbConnection());

            //CartRepository = cartRepository;
            //CartItemRepository = cartItemRepository;
            //OrderRepository = orderRepository;
            //OrderItemRepository = orderItemRepository;
            //WishListRepository = wishListRepository;
            //WishListItemRepository = wishListItemRepository;
            //ReviewRepository = reviewRepository;
        }

    }
}
