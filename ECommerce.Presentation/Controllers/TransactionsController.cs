using ECommerce.Repository.Abstraction.UnitOfWork;
using ECommerce.Repository.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(IUnitOfWork services) : ControllerBase
    {
        [HttpGet("get")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] string? hour,
            [FromQuery] string? day,
            [FromQuery] string? month,
            [FromQuery] string? year,
            [FromQuery] string? sellerId,
            [FromQuery] string? productId
            )
        {
            var transactions = await services.TransactionServices.GetAllTransactions(hour, day, month, year);
            return Ok(transactions);
        }

        [HttpPost("make-new-transaction")]
        public async Task<IActionResult> MakeNewTransaction(TransactionToAddModel model)
        {
            return Ok();
        }
    }
}
