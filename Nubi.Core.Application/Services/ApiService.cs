namespace Nubi.Core.Application.Services
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class ApiService : IApiServices
    {
        private readonly UrlBase _urlBase;

        public ApiService(IOptions<UrlBase> urlBase)
        {
            _urlBase = urlBase.Value;
        }

        public async Task<Response> GetAsync<T>(string prefix, string controller, CancellationToken cancellationToken)
        {
            try
            {
                var url = string.Empty;
                var answer = string.Empty;

                url = $"{_urlBase.UrlServer}{prefix}{controller}";

                using var client = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Get, url);

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                var stream = await response.Content.ReadAsStreamAsync();


                if (response.IsSuccessStatusCode == false)
                {
                    return new Response
                    {
                         StatudCode = false,
                        Result = StreamToStringAsync(stream)
                    };
                    
                }

                return new Response
                {
                    StatudCode = true,
                    Result = DeserializeJsonFromStream<T>(stream),
                    Message = "Ok"
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

        public Task<Response> PostAsync<T>(string prefix, string controller, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

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
        }
    }
}
