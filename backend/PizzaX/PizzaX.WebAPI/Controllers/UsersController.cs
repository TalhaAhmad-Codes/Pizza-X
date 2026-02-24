using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.UserDTOs;
using PizzaX.Application.DTOs.UserDTOs.UserUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] UserFilterDto dto)
        {
            try
            {
                var result = await service.GetAllAsync(dto);
                return Ok(result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await service.GetByIdAsync(id);
                return user is null ? NotFound() : Ok(user);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto dto)
        {
            try
            {
                var user = await service.CreateAsync(dto);
                return Ok(user);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Email must be unique. And username can't exceed 20 characters.");
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(CreateBulkDto<CreateUserDto> dtos)
        {
            try
            {
                await service.CreateBulkAsync(dtos);
                return Ok($"All {dtos.Items.Count} users has been inserted successfully.");
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (DbUpdateException e)
            {
                return BadRequest("Email must be unique. And username can't exceed 20 characters.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var result = await service.RemoveAsync(id);
            return result ? Ok("User has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/profile-pic")]
        public async Task<IActionResult> UpdateProfilePicAsync(UserUpdateProfilePicDto dto)
        {
            var result = await service.UpdateProfilePic(dto);
            return result ? Ok($"Profile picture of the user has been updated successfully") : NotFound();
        }

        [HttpPatch("update/username")]
        public async Task<IActionResult> UpdateUsernameAsync(UserUpdateUsernameDto dto)
        {
            try
            {
                var result = await service.UpdateUsernameAsync(dto);
                return result ? Ok($"Username of the user has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/email")]
        public async Task<IActionResult> UpdateEmailAsync(UserUpdateEmailDto dto)
        {
            try
            {
                var result = await service.UpdateEmailAsync(dto);
                return result ? Ok($"Email of the user has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/password")]
        public async Task<IActionResult> UpdateProfilePicAsync(UserUpdatePasswordDto dto)
        {
            try
            {
                var result = await service.UpdatePasswordAsync(dto);
                return result ? Ok($"Password of the user has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
