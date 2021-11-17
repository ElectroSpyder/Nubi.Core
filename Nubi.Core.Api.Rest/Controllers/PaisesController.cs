using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubi.Core.Application.Interfaces;

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


    }
}
