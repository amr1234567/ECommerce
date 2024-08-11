using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Core.Repositories.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class ProductResponse
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? DiscountPrecentage { get; set; }
        public DateTime? FinalDateForDiscount { get; set; }
        public DateTime? FirstDateForDiscount { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string SellerId { get; set; }
        public string SellerName { get; set; }

        public ProductResponse(ProductSellerCategorySubCategory model)
        {
            ProductDescription = model.ProductDescription;
            DiscountPrecentage = model.DiscountPrecentage;
            FinalDateForDiscount = model.FinalDateForDiscount;
            FirstDateForDiscount = model.FirstDateForDiscount;
            ProductPrice = model.ProductPrice;
            ProductQuantity = model.ProductQuantity;
            CategoryId = model.CategoryId;
            CategoryName = model.CategoryName;
            ProductId = model.ProductId;
            ProductName = model.ProductName;
            SubCategoryId = model.SubCategoryId;
            SubCategoryName = model.SubCategoryName;
            SellerId = model.SellerId;
            SellerName = model.SellerName;
        }
        public ProductResponse(Product product, IManagerRepository managerRepository)
        {
            ProductPrice = product.RealPrice;
            ProductDescription = product.Description;
            CategoryName = managerRepository.CategoryRepository.GetCategoryById(product.CategoryId).Result.Name;
            SellerName = managerRepository.SellerRepository.GetSellerById(product.SellerId).Result.Name;
            SubCategoryName = string.IsNullOrEmpty(SubCategoryId) ?
                string.Empty :
                managerRepository.SubCategoryRepository.GetSubCategoryBuyId(product.SubCategoryId).Result.Name;
            ProductQuantity = product.Quantity;
            CategoryId = product.CategoryId;
            ProductId = product.Id;
            ProductName = product.Name;
            SubCategoryId = product.SubCategoryId;
            SellerId = product.SellerId;
            DiscountPrecentage = product.Discount is not null ? product.Discount.DiscountPercentage : 0;
            FirstDateForDiscount = product.Discount is not null ? product.Discount.FirstDate : null;
            FinalDateForDiscount = product.Discount is not null ? product.Discount.FinalDate : null;
        }
        public ProductResponse()
        {

        }
    }
}
