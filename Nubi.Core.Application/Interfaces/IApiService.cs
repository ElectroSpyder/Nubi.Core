namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.Threading;
    using System.Threading.Tasks;
    public interface IApiServices
    {
        public Task<Response> GetAsync<T>(string prefix, string controller, CancellationToken cancellationToken);
        public Task<Response> PostAsync<T>(string prefix, string controller, CancellationToken cancellationToken);
    }
}
