using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Users;
using ECommerce.Core.Entities.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Context
{
    public class ECommerceContext : IdentityDbContext<User>
    {
        public static ECommerceContext Create(IMongoDatabase mongoDatabase)
        {
            var optionBuilder = new DbContextOptionsBuilder<ECommerceContext>();
            optionBuilder.LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
            return new ECommerceContext(optionBuilder.Options);
        }
        public ECommerceContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BugReport> BugReports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BsonClassMap.RegisterClassMap<IdentityUser>().AddKnownType(typeof(User));
            builder.Entity<BugReport>().ToCollection("bug_reports").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<Category>().ToCollection("categories").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<Product>().ToCollection("products").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<Seller>().ToCollection("sellers").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<ShopCart>().ToCollection("shop_carts").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<SubCategory>().ToCollection("sub_categories").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<Transaction>().ToCollection("transactions").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<Discount>().ToCollection("discounts").Property(b => b.Id).HasConversion<ObjectId>();
            //builder.Entity<Admin>().ToCollection("admins").Property(b => b.Id).HasConversion<ObjectId>();
            //builder.Entity<Consumer>().ToCollection("consumers").Property(b => b.Id).HasConversion<ObjectId>();
            //builder.Entity<Delivery>().ToCollection("delivery").Property(b => b.Id).HasConversion<ObjectId>();
            builder.Entity<User>().ToCollection("users").Property(b => b.Id).HasConversion<ObjectId>();
            //builder.Entity<User>().Property()

        }
    }
}
