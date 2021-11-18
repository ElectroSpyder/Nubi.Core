namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.Threading.Tasks;
    public interface ICurrencie
    {
        Task<Response> GetDataFromNubimetric();
    }
}
