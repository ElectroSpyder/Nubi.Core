namespace Nubi.Core.Application.Services
{
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using Nubi.Core.Domain.Interfaces;
    using Nubi.Core.Domain.Models;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.Collections.Generic;
    using Nubi.Core.Application.Mappring;

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

                var result = await _apiServices.GetAsync("/classified_locations/countries/", id, token);
                if (result != null)
                {
                   
                    return new Response
                    {
                        StatudCode = true,
                        Result = JsonConvert.DeserializeObject<Temperatures>(result),
                        Message = "Ok"
                    };
                }                  

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

        public async Task<Response> GetBusqueda(string busqueda)
        {
            try
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var result = await _apiServices.GetAsync("/sites/MLA/", "search?q=" + busqueda, token);
         

                if (result != null)
                {
                    var rootFromJson = JsonConvert.DeserializeObject<Root>(result);

                    JObject jobject = JObject.Parse(result);
                    var list = jobject["results"].ToList();
                    var listSearch = new List<SearchDTO>();

                    foreach (var item in list)
                    {
                        var itemId = (string)item["id"];
                        var siteId = (string)item["site_id"];
                        var title = (string)item["title"];
                        var price = (string)item["price"];
                        var sellerId = string.Empty;
                        var sellerPermalink = string.Empty;

                        JToken jSeller = item["seller"];
                        
                            sellerId = (string)jSeller["id"];
                            sellerPermalink = (string)jSeller["permalink"];
                            
                        listSearch.Add
                            (
                            new SearchDTO
                            {
                                Id = itemId,
                                Site = siteId,
                                Title = title,
                                Price = price,
                                SellerId = sellerId,
                                SellerPermalink = sellerPermalink,
                            }
                        ); 
                        
                    }
                    
                    return new Response
                    {
                        StatudCode = true,
                        Result = EntityMapper.FromRootToRootDTO(rootFromJson,listSearch), //JsonConvert.DeserializeObject<Temperatures>(result),
                        Message = "Ok"
                    };
                }
                    

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

        /*private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }*/
    }
}
