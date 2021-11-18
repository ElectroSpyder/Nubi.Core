using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubi.Core.Application.DTO;
using Nubi.Core.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Nubi.Core.Api.Rest.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllUsuarioAsync()
        {
            try
            {
                var result = await _userService.GetAllUser();
                if(result == null) return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }
        [HttpPost("/add")]
        public async Task<IActionResult> AddUserAsync(UserDTO userDTO)
        {
            try
            {
                var result = await _userService.AddUser(userDTO);
                if (result == null) return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }
        [HttpPut("/update/{id:int}")]
        public async Task<IActionResult> UpdateUsuarioAsync(UserDTO userDTO, int id)
        {
            try
            {
                var result = await _userService.UpdateUser(userDTO, id);
                if (result == null) return BadRequest();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }

        [HttpGet("/delete")]
        public async Task<IActionResult> DeleteUsuarioAsync(int id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                if (result == null) return BadRequest();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }
    }
}
