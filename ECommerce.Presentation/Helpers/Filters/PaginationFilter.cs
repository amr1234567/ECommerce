using ECommerce.Presentation.Models;
using ECommerce.Repository.Models.OutputModels.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presentation.Helpers.Filters
{

    public class PaginationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        { // Execute the action method
            var resultContext = await next();

            // Check if the result is an OkObjectResult containing an IQueryable
            if (resultContext.Result is OkObjectResult okObjectResult && okObjectResult.Value is IQueryable queryable)
            {
                // Parse pagination parameters from the query string
                var queryParams = context.HttpContext.Request.Query;
                int pageNumber = int.TryParse(queryParams["pageNumber"], out var page) ? page : 1;
                int pageSize = int.TryParse(queryParams["pageSize"], out var size) ? size : 10;
                string sortDirection = queryParams["sortDirection"].ToString().ToLower() ?? "asc";

                // Cast queryable to IQueryable<object>
                var queryableData = (IQueryable<object>)queryable;

                if (sortDirection == "desc")
                {
                    queryableData = queryableData.OrderByDescending(e => e); // Adjust sorting logic based on the actual data type
                }
                else
                {
                    queryableData = queryableData.OrderBy(e => e); // Adjust sorting logic based on the actual data type
                }
                // Apply pagination and sorting
                var totalRecords = queryableData.Count();
                var pagedData = queryableData
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);


                // Convert to a list and wrap in a paged response
                var pagedList = pagedData.ToList();
                var pagedResponse = new PagedResponse<object>(pagedList, totalRecords, pageNumber, pageSize);

                // Set the paged response as the result
                resultContext.Result = new OkObjectResult(new CustomResponseModel<PagedResponse<object>>
                {
                    Body = pagedResponse,
                    StatusCode = 200,
                    Message = "Date Returned"
                });
            }
        }

    }
}
