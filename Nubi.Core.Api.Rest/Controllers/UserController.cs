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

        /// <summary>
        /// Metodo que retorna todos los usarios del systema
        /// </summary>
        /// <returns>List of User</returns>
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

        /// <summary>
        /// Metodo que permite agregar un obetjo del tipo Usuario
        /// </summary>
        /// <param name="userDTO">contiene {Nombre, Apellido, Email y Password, ademas de otros atributos}</param>
        /// <returns>Ok</returns>
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

        /// <summary>
        /// Metodo que permite actualizar un Usuario
        /// </summary>
        /// <param name="userDTO">contiene {Nombre, Apellido, Email y Password, ademas de otros atributos}</param>
        /// <param name="id">contiene el identificador unico del sistema</param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que permite dar de baja un usuario, de forma logica
        /// </summary>
        /// <param name="id">Identificador del usuario a dar de baja</param>
        /// <returns></returns>
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
