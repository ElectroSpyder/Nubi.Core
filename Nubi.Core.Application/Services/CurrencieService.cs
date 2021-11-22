﻿namespace Nubi.Core.Application.Services
{
    using Newtonsoft.Json;
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using static Nubi.Core.Application.DTO.RootCurrencieDTO;

    public class CurrencieService : ICurrencie
    {
        private readonly IApiServices _apiServices;

        public CurrencieService(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public async Task<Response> GetDataFromNubimetric()
        {
            try
            {
                /*var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;

                var result = await _apiServices.GetAsync("/currencies/", null, token);*/

                var currencies = await GetCurrencie();
                var root = JsonConvert.DeserializeObject<RootCurrencieDTO[]>(currencies);

                foreach (var item in root)
                {
                    var result = await GetCurrencyConversions(item.id);
                    var todolar = JsonConvert.DeserializeObject<ToDolar>(result);
                    if (todolar != null)
                        item.todolar = todolar;

                }
               
                
                if (currencies == null)
                    return new Response
                    {
                        StatudCode = false,
                        Message = "Error",
                        Result = null
                    };

                //var rootFromJson = JsonConvert.DeserializeObject<Root>(result);

                return new Response
                {
                    StatudCode = true,
                    Message = "Correcto",
                    Result = root
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

        private async Task<string> GetCurrencie()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var result = await _apiServices.GetAsync("/currencies/", null, token);
            return result;
        }

        private async Task<string> GetCurrencyConversions(string id)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var result = await _apiServices.GetAsync("/currency_conversions/search?from=" + id, "&to=USD", token);
            return result;
        }
    }
}
