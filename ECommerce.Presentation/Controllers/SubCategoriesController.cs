using DnsClient;
using ECommerce.Core.Exceptions;
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
    public class SubCategoriesController(IUnitOfWork services) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add(SubCategoryToAddModel model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Add));
            var res = await services.SubCategoryServices.AddSubCategory(model);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "SubCategory Added Successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Body = true,
                Message = "SubCategory Can't be added",
                StatusCode = 400
            });
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(SubCategoryToEditModel model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Edit));
            var subCategory = await services.SubCategoryServices.EditSubCategory(model);
            return Ok(new CustomResponseModel<SubCategoryResponse>
            {
                Body = subCategory,
                Message = "SubCategory Updated",
                StatusCode = 200
            });
        }

        [HttpPost("change-category/{id}/{newCategoryId}")]
        public async Task<IActionResult> Edit([Required] string id, [Required] string newCategoryId)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Edit));
            var subCategory = await services.SubCategoryServices.ChangeCategoryOfSubCategory(id, newCategoryId);
            return Ok(new CustomResponseModel<SubCategoryResponse>
            {
                Body = subCategory,
                Message = "SubCategory Updated",
                StatusCode = 200
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Edit));
            var subCategory = await services.SubCategoryServices.DeleteSubCategory(id);
            return Ok(new CustomResponseModel<SubCategoryResponse>
            {
                Body = subCategory,
                Message = "SubCategory Deleted",
                StatusCode = 200
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subCategories = await services.SubCategoryServices.GetAllSubCategories();
            return Ok(subCategories);
        }

        [HttpGet("in-seller/{sellerId}")]
        public async Task<IActionResult> Get([Required] string sellerId)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Get));
            var subCategories = await services.SubCategoryServices.GetAllSubCategoriesForSeller(sellerId);
            return Ok(subCategories);
        }
    }
}
