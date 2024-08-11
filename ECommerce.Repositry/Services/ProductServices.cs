

using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;

namespace ECommerce.Repository.Services
{
    internal class ProductServices(IManagerRepository managerRepository) : IProductServices
    {
        public async Task<ProductResponse> AddNewDiscount(string productId, PeriodDiscount discount)
        {
            if (discount == null)
                throw new ParameterIsNullOrEmptyException(nameof(discount));
            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            if (discount.DiscountPercentage is null || discount.DiscountPercentage == 0)
                throw new ParameterIsNullOrEmptyException(nameof(discount.DiscountPercentage));
            if (discount.FinalDate == null)
                throw new ParameterIsNullOrEmptyException(nameof(discount.FinalDate));
            if (discount.FirstDate == null)
                throw new ParameterIsNullOrEmptyException(nameof(discount.FirstDate));
            NotValidDateException.ThrowIfDateInValid(discount.FinalDate);
            NotValidDateException.ThrowIfDateInValid(discount.FirstDate);

            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = discount,
                CategoryId = null,
                Description = null,
                Name = null,
                Quantity = -1,
                RealPrice = -1,
                SellerId = null,
                SubCategoryId = null
            });
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<bool> AddNewProduct(ProductToAddModel model)
        {
            var seller = await managerRepository.SellerRepository.GetSellerById(model.SellerId);
            if(!seller.SubCategoriesIds.Contains(model.SubCategoryId))
                await managerRepository.SellerRepository.AddNewSubCategoriesToSeller(seller.Id, model.SubCategoryId);
            var res = await managerRepository.ProductRepository.AddNewProduct(model.ToModel());
            return res;
        }

        public async Task<ProductResponse> ChangeCategoryForProduct(string productId, string newCategoryId)
        {
            var product = await managerRepository.ProductRepository.ChangeCategoryForProduct(productId, newCategoryId);
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> ChangeDetails(string productId, ProductToEditModel model)
        {
            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            if (model == null)
                throw new ParameterIsNullOrEmptyException(nameof(model));

            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = null,
                CategoryId = null,
                Description = model.Description,
                Name = model.Name,
                Quantity = -1,
                RealPrice = -1,
                SellerId = null,
                SubCategoryId = null
            });

            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> ChangePrice(string productId, double newPrice)
        {
            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            if (newPrice == 0)
                throw new ParameterIsNullOrEmptyException(nameof(newPrice));

            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = null,
                CategoryId = null,
                Description = null,
                Name = null,
                Quantity = -1,
                RealPrice = newPrice,
                SellerId = null,
                SubCategoryId = null
            });

            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> ChangeSubCategoryForProduct(string productId, string newSubCategoryId)
        {
            var product = await managerRepository.ProductRepository.ChangeSubCategoryForProduct(productId, newSubCategoryId);
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> DeleteProduct(string productId)
        {
            var product = await managerRepository.ProductRepository.DeleteProduct(productId);
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<IQueryable<ProductResponse>> GetAllProducts()
        {
            var products = await managerRepository.ProductRepository.GetAllProducts();
            return products.Select(product => new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            }).OrderBy(p => p.ProductPrice);
        }

        public async Task<IQueryable<ProductResponse>> GetAllProductsForSeller(string sellerId)
        {
            var products = await managerRepository.ProductRepository.GetAllProductsForSeller(sellerId);
            return products.Select(product => new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            }).OrderBy(p => p.ProductPrice);
        }

        public async Task<IQueryable<ProductResponse>> GetAllProductsInCategory(string categoryId)
        {
            var products = await managerRepository.ProductRepository.GetAllProductsInCategory(categoryId);
            return products.Select(product => new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            }).OrderBy(p => p.ProductPrice);
        }

        public async Task<IQueryable<ProductResponse>> GetAllProductsInSubCategory(string subCategoryId)
        {
            var products = await managerRepository.ProductRepository.GetAllProductsInSubCategory(subCategoryId);
            return products.Select(product => new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            }).OrderBy(p => p.ProductPrice);
        }

        public async Task<ProductResponse> GetProductById(string productId)
        {
            var product = await managerRepository.ProductRepository.GetProductById(productId);
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> IncreaseQuantityOfProductBy(string productId, int quantity)
        {

            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            var originalProduct = await managerRepository.ProductRepository.GetProductById(productId);
            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = null,
                CategoryId = null,
                Description = null,
                Name = null,
                Quantity = originalProduct.ProductQuantity + quantity,
                RealPrice = -1,
                SellerId = null,
                SubCategoryId = null
            });

            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> RemoveDiscountIfExist(string productId)
        {
            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = new PeriodDiscount
                {
                    DiscountPercentage = -1
                },
                CategoryId = null,
                Description = null,
                Name = null,
                Quantity = -1,
                RealPrice = -1,
                SellerId = null,
                SubCategoryId = null
            });

            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }

        public async Task<ProductResponse> TransferProductToNewSeller(string productId, string sellerId)
        {
            if (productId == null)
                throw new ParameterIsNullOrEmptyException(nameof(productId));
            if (sellerId == null)
                throw new ParameterIsNullOrEmptyException(nameof(sellerId));
            var seller = await managerRepository.SellerRepository.GetSellerById(sellerId);
            var originalProduct = await managerRepository.ProductRepository.GetProductById(productId);
            if (!seller.CategoryId.Equals(originalProduct.CategoryId))
                throw new SellerAssignToAnotherCategoryException(sellerId);
            if (!seller.SubCategoriesIds.Contains(originalProduct.SubCategoryId))
            {
                await managerRepository.SellerRepository.AddNewSubCategoriesToSeller(sellerId, originalProduct.SubCategoryId);
            }
            var product = await managerRepository.ProductRepository.UpdateProductDetails(new Product
            {
                Id = productId,
                Discount = new PeriodDiscount
                {
                    DiscountPercentage = -1
                },
                CategoryId = null,
                Description = null,
                Name = null,
                Quantity = -1,
                RealPrice = -1,
                SellerId = sellerId,
                SubCategoryId = null
            });
            return new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            };
        }


    }
}
