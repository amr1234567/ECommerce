using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Views
{
    public class ProductSellerCategorySubCategory
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? DiscountAmountOfProduct { get; set; }
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
    }
}
