using MaleFashion.Domain.Entities;
using MaleFashion.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaleFashion.Infrastructure.Data;

namespace MaleFashion.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
        IdentityDbContext<ApplicationUser,
        ApplicationRole,
        Guid,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<WishList> WishLists { get; set; }
        //public DbSet<WishListItem> WishListItems { get; set; }
        //public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasOne(x => x.Category)
            //          .WithMany(x => x.Products)
            //          .HasForeignKey(x => x.CategoryId);
            //});


            //modelBuilder.Entity<ProductImage>(entity =>
            //{
            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.ProductImages)
            //          .HasForeignKey(x => x.ProductId);
            //});



            //modelBuilder.Entity<ProductVariant>(entity =>
            //{
            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.ProductVariants)
            //          .HasForeignKey(x => x.ProductId);

            //});

            //modelBuilder.Entity<Cart>(entity =>
            //{
            //    entity.HasOne(x => x.User)
            //          .WithOne(x => x.Cart)
            //          .HasForeignKey<Cart>(x => x.UserId);
            //});

            //modelBuilder.Entity<CartItem>(entity =>
            //{
            //    entity.HasOne(x => x.Cart)
            //          .WithMany(x => x.CartItems)
            //          .HasForeignKey(x => x.CartId);

            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.CartItems)
            //          .HasForeignKey(x => x.ProductId);

            //    entity.HasOne(x => x.Size)
            //          .WithMany()
            //          .HasForeignKey(x => x.SizeId);

            //    entity.HasOne(x => x.Color)
            //          .WithMany()
            //          .HasForeignKey(x => x.ColorId);
            //});

            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.HasOne(x => x.User)
            //          .WithMany(x => x.Orders)
            //          .HasForeignKey(x => x.UserId);
            //});

            //modelBuilder.Entity<OrderItem>(entity =>
            //{
            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.OrderItems)
            //          .HasForeignKey(x => x.ProductId);

            //    entity.HasOne(x => x.Order)
            //          .WithMany(x => x.OrderItems)
            //          .HasForeignKey(x => x.OrderId);
            //});

            //modelBuilder.Entity<WishList>(entity =>
            //{
            //    entity.HasOne(x => x.User)
            //          .WithOne(x => x.WishList)
            //          .HasForeignKey<WishList>(x => x.UserId);
            //});

            //modelBuilder.Entity<WishListItem>(entity =>
            //{
            //    entity.HasOne(x => x.WishList)
            //          .WithMany(x => x.WishlistItems)
            //          .HasForeignKey(x => x.WishListId);

            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.WishlistItems)
            //          .HasForeignKey(x => x.ProductId);
            //});

            //modelBuilder.Entity<Review>(entity =>
            //{
            //    entity.HasOne(x => x.Product)
            //          .WithMany(x => x.Reviews)
            //          .HasForeignKey(x => x.ProductId);

            //    entity.HasOne(x => x.User)
            //          .WithMany(x => x.Reviews)
            //          .HasForeignKey(x => x.UserId);
            //});

            modelBuilder.Entity<ApplicationRole>().HasData(Seeds.RoleSeeds.GetRoles());

        }
    }
}
