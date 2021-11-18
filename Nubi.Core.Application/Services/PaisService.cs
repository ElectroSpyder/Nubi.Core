namespace Nubi.Core.Application.Services
{
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using Nubi.Core.Domain.Interfaces;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class PaisService : IPaisService
    {       
        private readonly IApiServices _apiServices;

        public PaisService(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public async Task<Response> GetPais(string id)
        {
            try
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var result = await _apiServices.GetAsync<Response>("/classified_locations/countries/", id, token);
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
