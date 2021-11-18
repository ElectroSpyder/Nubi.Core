namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.Threading.Tasks;

    public interface IPaisService
    {
        Task<Response> GetPais(string id);
        Task<Response> GetBusqueda(string busqueda);
    }
}
