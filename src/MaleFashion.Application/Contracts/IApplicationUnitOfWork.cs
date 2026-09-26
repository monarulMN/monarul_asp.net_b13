using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Application.Contracts
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }

        //public ICartRepository CartRepository { get; }
        //public ICartItemRepository CartItemRepository { get; }
        //public IOrderRepository OrderRepository { get; }
        //public IOrderItemRepository OrderItemRepository { get; }
        //public IWishListRepository WishListRepository { get; }
        //public IWishListItemRepository WishListItemRepository { get; }
        //public IReviewRepository ReviewRepository { get; }

    }
}
