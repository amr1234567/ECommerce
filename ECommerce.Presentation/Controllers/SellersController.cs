using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Repository.Abstraction.UnitOfWork;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using ECommerce.Repository.Models.OutputModels.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController(IUnitOfWork services) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellers = await services.SellerServices.GetAllSellers();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] string id)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Get));
            var seller = await services.SellerServices.GetSellerById(id);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller Returned Successfully",
                StatusCode = 200
            });
        }

        [HttpGet("products/{sellerId}")]
        public async Task<IActionResult> GetAllProducts([Required] string sellerId)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(GetAllProducts));
            var sellers = await services.SellerServices.GetAllProductsForSeller(sellerId);
            return Ok(sellers);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SellerToAddModel model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Add));
            var res = await services.SellerServices.GenerateNewSeller(model);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "Seller Generated Successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Body = true,
                Message = "Seller Can't be Generated",
                StatusCode = 400
            });
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Update(SellerToEditModel model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Update));
            var seller = await services.SellerServices.UpdateSellerDetails(model);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller updated successfully",
                StatusCode = 200
            });
        }

        [HttpPost("change-type/{sellerId}/{type}")]
        public async Task<IActionResult> ChangeType([Required] string sellerId, [Required] SellerTypes type)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(ChangeType));
            var seller = await services.SellerServices.ChangeTypeOfSeller(sellerId, type);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller updated successfully",
                StatusCode = 200
            });
        }

        [HttpPost("change-category/{sellerId}/{categoryId}")]
        public async Task<IActionResult> ChangeType([Required] string sellerId, [Required] string categoryId)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(ChangeType));
            var seller = await services.SellerServices.ChangeCategoryOfSeller(sellerId, categoryId);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller updated successfully",
                StatusCode = 200
            });
        }

        [HttpPost("add-sub-categories/{sellerId}")]
        public async Task<IActionResult> AddSubCategoriesToSeller([Required] string sellerId, [Required] params string[] subCategoriesIds)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(AddSubCategoriesToSeller));
            var seller = await services.SellerServices.AddNewSubCategoriesToSeller(sellerId, subCategoriesIds);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller updated successfully",
                StatusCode = 200
            });
        }

        [HttpPost("remove-sub-categories/{sellerId}")]
        public async Task<IActionResult> RemoveSubCategoriesToSeller([Required] string sellerId, [Required] params string[] subCategoriesIds)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(RemoveSubCategoriesToSeller));
            var seller = await services.SellerServices.RemoveSubCategoriesFromSeller(sellerId, subCategoriesIds);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller updated successfully",
                StatusCode = 200
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Delete));
            var seller = await services.SellerServices.DeleteSeller(id);
            return Ok(new CustomResponseModel<SellerResponse>
            {
                Body = seller,
                Message = "Seller deleted successfully",
                StatusCode = 200
            });
        }
    }
}
