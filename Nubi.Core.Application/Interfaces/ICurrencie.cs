namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.Threading.Tasks;
    public interface ICurrencie
    {
        Task<ResponseWeb> GetDataFromNubimetric();
        Task<ResponseWeb> WriteJson(RootCurrencieDTO[] root);
        bool WriteSCVFile(RootCurrencieDTO[] root);
    }
}
