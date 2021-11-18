using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubi.Core.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Nubi.Core.Api.Rest.Controllers
{
    [ApiController]
    [Route("[Controller]")]    
    public class PaisesController : ControllerBase
    {
        private readonly IPaisService _paisService;

        public PaisesController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet("/pais")]
        public async Task<IActionResult> GetUserInfo(string pais)
        {
            try
            {
                if(string.IsNullOrEmpty(pais))
                    return StatusCode(StatusCodes.Status204NoContent, $"Advertencia, debe ingresar un valor ");
                if (pais == "BR" || pais == "CO")
                    return StatusCode(StatusCodes.Status401Unauthorized);

                var result = await _paisService.GetPais(pais);
                if(result.StatudCode)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }

        [HttpGet("/busqueda")]
        public async Task<IActionResult> GetBusqueda(string busqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(busqueda))
                    return StatusCode(StatusCodes.Status204NoContent, $"Advertencia, debe ingresar un valor valido");
                var result = await _paisService.GetBusqueda(busqueda);
                if (result.StatudCode)
                    return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error : {ex.Message}");
            }
        }
    }

}
