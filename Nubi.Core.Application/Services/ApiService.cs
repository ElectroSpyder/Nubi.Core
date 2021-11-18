namespace Nubi.Core.Application.Services
{
    using Microsoft.Extensions.Options;
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    public class ApiService : IApiServices
    {
        private readonly UrlBase _urlBase;

        public ApiService(IOptions<UrlBase> urlBase)
        {
            _urlBase = urlBase.Value;
        }

        public async Task<string> GetAsync(string controller, string prefix, CancellationToken cancellationToken)
        {
            try
            {
                var url = string.Empty;
                var answer = string.Empty;
                if(string.IsNullOrEmpty(prefix))
                    url = $"{_urlBase.UrlServer}{controller}";
                url = $"{_urlBase.UrlServer}{controller}{prefix}";

                using var client = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, url);

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                return await response.Content.ReadAsStringAsync();
                /*var stream = await response.Content.ReadAsStreamAsync();


                if (response.IsSuccessStatusCode == false)
                {
                    return new Response
                    {
                         StatudCode = false,
                        Result = null
                    };
                    
                }

                return new Response
                {
                    StatudCode = true,
                    Result = DeserializeJsonFromStream<Temperatures>(stream),
                    Message = "Ok"
                };*/

            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        public Task<Response> PostAsync<T>(string prefix, string controller, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        /*
        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
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
        }*/
    }
}
