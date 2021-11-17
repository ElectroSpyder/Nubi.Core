namespace Nubi.Core.Application.Services
{
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using Nubi.Core.Domain.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class PaisService : IPaisService
    {       

        public async Task<Response> GetPais(string id)
        {
            try
            {

                return new Response
                {
                    StatudCode = false,
                    Message = "Error inesperado"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    StatudCode = false,
                    Message = ex.Message
                };
            }
        }
    }
}
