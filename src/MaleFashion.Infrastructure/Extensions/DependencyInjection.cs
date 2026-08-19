using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Domain.Entities;
using MaleFashion.Infrastructure.Data;
using MaleFashion.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            // Add your infrastructure services here
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IWishListRepository, WishListRepository>();
            services.AddScoped<IWishListItemRepository, WishListItemRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            // For example, you can add database context, repositories, etc.
            return services;
        }
    }
}
