using ECommerce.Core.Helpers.Classes;
using ECommerce.Repository.Abstraction.UnitOfWork;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using ECommerce.Repository.Models.OutputModels.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IUnitOfWork services) : ControllerBase
    {
        //[Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await services.CategoryServices.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await services.CategoryServices.GetCategoryById(id);
            return Ok(new CustomResponseModel<CategoryResponse>
            {
                Body = category,
                Message = " category returned",
                StatusCode = 200
            });
        }

        //[Authorize(Roles = UserRolesAsConstants.Admin)]
        [HttpPost("edit")]
        public async Task<IActionResult> Update(CategoryToEditModel model)
        {
            var category = await services.CategoryServices.EditCategoryDetails(model);
            return Ok(new CustomResponseModel<CategoryResponse>
            {
                Body = category,
                Message = " category updated",
                StatusCode = 200
            });
        }

        //[Authorize(Roles = UserRolesAsConstants.Admin)]
        [HttpPost("add")]
        public async Task<IActionResult> Generate(CategoryToAddModel model)
        {
            var res = await services.CategoryServices.AddNewCategory(model);
            return Ok(new CustomResponseModel<bool>
            {
                Body = res,
                Message = " category updated",
                StatusCode = 200
            });
        }
    }
}
