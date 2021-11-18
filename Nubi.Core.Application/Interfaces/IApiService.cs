namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IApiServices
    {
        public Task<string> GetAsync(string controller, string prefix, CancellationToken cancellationToken);
        public Task<Response> PostAsync<T>(string prefix, string controller, CancellationToken cancellationToken);
    }
}
