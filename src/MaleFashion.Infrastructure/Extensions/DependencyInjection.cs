using MaleFashion.Application.Contracts;
using MaleFashion.Application.Contracts.Repositories;
using MaleFashion.Application.Contracts.Services;
using MaleFashion.Domain.Entities;
using MaleFashion.Infrastructure.Data;
using MaleFashion.Infrastructure.Data.Repositories;
using MaleFashion.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, string rootPath)
        {
            // Add your infrastructure services here
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            //services.AddScoped<IProductVariantRepository, ProductVariantRepository>();

            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ICartRepository, CartRepository>();
            //services.AddScoped<ICartItemRepository, CartItemRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            //services.AddScoped<IWishListRepository, WishListRepository>();
            //services.AddScoped<IWishListItemRepository, WishListItemRepository>();
            //services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IFileStorageService, FileStorageService>(x => new FileStorageService(rootPath));
            //services.AddSingleton<ISqlUtility, SqlUtility>();
            services.AddSingleton<IServerTime, ServerTime>();

            services.AddScoped<IUserRepository, UserRepository>();


            // For example, you can add database context, repositories, etc.
            return services;
        }
    }
}
