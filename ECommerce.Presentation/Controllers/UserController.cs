using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Classes;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Presentation.Models;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using ECommerce.Repository.Models.OutputModels.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController(IUserServices userServices) : ControllerBase
    {
        [ProducesResponseType(typeof(CustomResponseModel<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<UserResponse>), StatusCodes.Status400BadRequest)]
        [HttpGet("get-admin/{id}")]
        //[Authorize(Roles = UserRolesAsConstants.Admin)]
        //[NonAction]
        public async Task<IActionResult> GetAdminById(string id)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(GetAdminById));
            return Ok(new CustomResponseModel<UserResponse>
            {
                Body = await userServices.GetAdminById(id),
                Message = "Admin return",
                StatusCode = 200
            });
        }

        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status400BadRequest)]
        [HttpPost("sign-up-consumer")]
        public async Task<IActionResult> RegisterAsConsumer(SignUpAsConsumerDto model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(RegisterAsConsumer));
            var res = await userServices.SignUp(model.ToInputModel(), UserRoles.Consumer);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "Consumer Added Successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Message = "Consumer Can't be Added",
                StatusCode = 400
            });

        }

        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status400BadRequest)]
        [HttpPost("sign-up-admin")]
        //[NonAction]
        //[Authorize(Roles = UserRolesAsConstants.Admin)]
        public async Task<IActionResult> RegisterAsAdmin(SignUpAsAdminDto model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(RegisterAsAdmin));
            var res = await userServices.SignUp(model.ToInputModel(), UserRoles.Admin);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "Admin Added Successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Message = "Admin Can't be Added",
                StatusCode = 400
            });
        }

        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status400BadRequest)]
        [HttpPost("sign-up-delivery")]
        //[Authorize(Roles = UserRolesAsConstants.Admin)]
        public async Task<IActionResult> RegisterAsDelivery(SignUpAsDeliveryDto model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(RegisterAsDelivery));
            var res = await userServices.SignUp(model.ToInputModel(), UserRoles.Delivery);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = true,
                    Message = "Delivery Added Successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Message = "Delivery Can't be Added",
                StatusCode = 400
            });
        }

        [ProducesResponseType(typeof(CustomResponseModel<TokenModel?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<TokenModel?>), StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Login));
            var res = await userServices.Login(model);
            if (res is not null)
                return Ok(new CustomResponseModel<TokenModel?>
                {
                    Body = res,
                    Message = "User Logged in successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<TokenModel?>
            {
                Body = null,
                Message = "User Can't Log in",
                StatusCode = 400
            });
        }

        [ProducesResponseType(typeof(CustomResponseModel<TokenModel?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<TokenModel?>), StatusCodes.Status400BadRequest)]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTheToken([Required] string refreshToken, [Required] string token)
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(RefreshTheToken));
            var res = await userServices.RefreshTheToken(refreshToken, token);
            if (res is not null)
                return Ok(new CustomResponseModel<TokenModel?>
                {
                    Body = res,
                    Message = "Refresh The Token Done successfully",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<TokenModel?>
            {
                Body = null,
                Message = "Can\'t refresh the token",
                StatusCode = 400
            });
        }

        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponseModel<bool>), StatusCodes.Status400BadRequest)]
        [HttpPost("log-out")]
        [Authorize(Roles = $"{UserRolesAsConstants.Consumer},{UserRolesAsConstants.Delivery},{UserRolesAsConstants.Admin}")]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
                throw new ModelStateNotValidException(nameof(Logout));
            if (string.IsNullOrEmpty(GetUserIdFromClaims()))
                throw new NoUserLoggedInException();
            var res = await userServices.Logout(GetUserIdFromClaims()!);
            if (res)
                return Ok(new CustomResponseModel<bool>
                {
                    Body = res,
                    Message = "user logged out",
                    StatusCode = 200
                });
            return BadRequest(new CustomResponseModel<bool>
            {
                Body = res,
                Message = "Can\'t log out the user",
                StatusCode = 400
            });
        }

        private string? GetUserIdFromClaims() =>
            User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
    }
}
