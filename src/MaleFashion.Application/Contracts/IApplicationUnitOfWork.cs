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
        public ISizeRepository SizeRepository { get; }
        public IProductSizeRepository ProductSizeRepository { get; }
        public IColorRepository ColorRepository { get; }
        public IProductColorRepository ProductColorRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IWishListRepository WishListRepository { get; }
        public IReviewRepository ReviewRepository { get; }
    }
}
