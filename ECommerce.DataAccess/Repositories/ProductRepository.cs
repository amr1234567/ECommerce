using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories
{
    internal class ProductRepository(ECommerceContext context) : IProductRepository
    {
        public async Task<bool> AddNewProduct(Product model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.Products.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductSellerCategorySubCategory> ChangeCategoryForProduct(string productId, string newCategoryId)
        {
            var product = await GetProductForInternalMethods(productId);
            product.CategoryId = newCategoryId;
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return await GetProductById(productId);
        }

        public async Task<ProductSellerCategorySubCategory> ChangeSubCategoryForProduct(string productId, string newSubCategoryId)
        {
            var product = await GetProductForInternalMethods(productId);
            product.SubCategoryId = newSubCategoryId;
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return await GetProductById(productId);
        }

        public async Task<ProductSellerCategorySubCategory> DeleteProduct(string productId)
        {
            var product = await GetProductForInternalMethods(productId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return await GetProductById(productId);
        }

        public Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProducts()
        {

            var products = context.Products.Select((p) => new ProductSellerCategorySubCategory
            {
                CategoryId = p.CategoryId,
                DiscountAmountOfProduct = p.Discount.DiscountAmount,
                FinalDateForDiscount = p.Discount.FinalDate,
                FirstDateForDiscount = p.Discount.FirstDate,
                ProductDescription = p.Description,
                ProductId = p.Id,
                ProductName = p.Name,
                ProductPrice = p.RealPrice,
                ProductQuantity = p.Quantity,
                SellerId = p.SellerId,
                SubCategoryId = p.SubCategoryId,
                CategoryName = context.Categories.FirstOrDefault(c => c.Id.Equals(p.CategoryId)).Name ?? "",
                SellerName = context.Sellers.FirstOrDefault(c => c.Id.Equals(p.SellerId)).Name ?? "",
                SubCategoryName = context.SubCategories.FirstOrDefault(c => c.Id.Equals(p.SubCategoryId)).Name ?? ""

            });
            return Task.FromResult(products);

        }

        public async Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsForSeller(string sellerId)
        {
            var products = await GetAllProducts();
            return products.Where(p => p.SellerId == sellerId);
        }

        public async Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsInCategory(string categoryId)
        {
            var products = await GetAllProducts();
            return products.Where(p => p.CategoryId == categoryId);
        }

        public async Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsInSubCategory(string subCategoryId)
        {
            var products = await GetAllProducts();
            return products.Where(p => p.SubCategoryId == subCategoryId);
        }

        public async Task<ProductSellerCategorySubCategory> GetProductById(string productId)
        {
            var product = await context.Products.Select((p) => new ProductSellerCategorySubCategory
            {
                CategoryId = p.CategoryId,
                DiscountAmountOfProduct = p.Discount.DiscountAmount,
                FinalDateForDiscount = p.Discount.FinalDate,
                FirstDateForDiscount = p.Discount.FirstDate,
                ProductDescription = p.Description,
                ProductId = p.Id,
                ProductName = p.Name,
                ProductPrice = p.RealPrice,
                ProductQuantity = p.Quantity,
                SellerId = p.SellerId,
                SubCategoryId = p.SubCategoryId,
            }).FirstOrDefaultAsync(p => p.ProductId.Equals(productId))
            ?? throw new NotFoundException($"product with id {productId}");

            product.CategoryName = context.Categories.FirstOrDefault(c => c.Id.Equals(product.CategoryId)).Name;
            product.SellerName = context.Sellers.FirstOrDefault(c => c.Id.Equals(product.SellerId)).Name;
            product.SubCategoryName = context.SubCategories.FirstOrDefault(c => c.Id.Equals(product.SubCategoryId)).Name;
            return product;
        }

        public async Task<ProductSellerCategorySubCategory> UpdateProductDetails(Product model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var product = await GetProductForInternalMethods(model.Id);
            product.Quantity = model.Quantity < 0 ? product.Quantity : model.Quantity;
            product.RealPrice = model.RealPrice < 0 ? product.RealPrice : model.RealPrice;
            product.Discount = model.Discount is null ? product.Discount : model.Discount;
            product.Name = string.IsNullOrEmpty(model.Name) ? product.Name : model.Name;
            product.Description = string.IsNullOrEmpty(model.Description) ? product.Description : model.Description;

            context.Products.Update(product);
            await context.SaveChangesAsync();
            return await GetProductById(product.Id);
        }

        private async Task<Product> GetProductForInternalMethods(string productId) =>
            await context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId))
                ?? throw new NotFoundException($"product with id {productId}");
    }
}
