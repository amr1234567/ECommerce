using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Presentation.Models;
using ECommerce.Repository.Abstraction.UnitOfWork;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using ECommerce.Repository.Models.OutputModels.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IUnitOfWork services) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Generate(ProductToAddModel model)
        {
            var res = await services.ProductServices.AddNewProduct(model);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "product added",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Message = "something wrong",
                StatusCode = 400
            });
        }

        [HttpPost("update-details/{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, ProductToEditModel model)
        {
            var product = await services.ProductServices.ChangeDetails(productId, model);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("update-price/{productId}")]
        public async Task<IActionResult> UpdateProductPrice(string productId, double newPrice)
        {
            var product = await services.ProductServices.ChangePrice(productId, newPrice);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("update-quantity/{productId}")]
        public async Task<IActionResult> UpdateProductQuantity(string productId, int quantity)
        {
            var product = await services.ProductServices.IncreaseQuantityOfProductBy(productId, quantity);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("add-discount/{productId}")]
        public async Task<IActionResult> AddDiscountToProduct(string productId, PeriodDiscount discount)
        {
            var product = await services.ProductServices.AddNewDiscount(productId, discount);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("remove-discount/{productId}")]
        public async Task<IActionResult> RemoveDiscountToProduct(string productId)
        {
            var product = await services.ProductServices.RemoveDiscountIfExist(productId);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("change-seller/{productId}/{sellerId}")]
        public async Task<IActionResult> RemoveDiscountToProduct(string productId, string sellerId)
        {
            var product = await services.ProductServices.TransferProductToNewSeller(productId, sellerId);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("update-category")]
        public async Task<IActionResult> ChangeCategoryForProduct(ChangeCategoryForProductInputModel model)
        {
            var product = await services.ProductServices.ChangeCategoryForProduct(model.productId, model.newCategoryId);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpPost("update-sub-category")]
        public async Task<IActionResult> ChangeSubCategoryForProduct(ChangeSubCategoryForProductModel model)
        {
            var product = await services.ProductServices.ChangeSubCategoryForProduct(model.productId, model.newSubCategoryId);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product updated",
                StatusCode = 200
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await services.ProductServices.DeleteProduct(id);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product deleted",
                StatusCode = 200
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await services.ProductServices.GetProductById(id);
            return Ok(new CustomResponseModel<ProductResponse>
            {
                Body = product,
                Message = "product returned",
                StatusCode = 200
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await services.ProductServices.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("by-seller/{id}")]
        public async Task<IActionResult> GetAllForSeller(string id)
        {
            var products = await services.ProductServices.GetAllProductsForSeller(id);
            return Ok(products);
        }

        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetAllInCategory(string id)
        {
            var products = await services.ProductServices.GetAllProductsInCategory(id);
            return Ok(products);
        }

        [HttpGet("by-sub-category/{id}")]
        public async Task<IActionResult> GetAllInSubCategory(string id)
        {
            var products = await services.ProductServices.GetAllProductsInSubCategory(id);
            return Ok(products);
        }
    }
}
