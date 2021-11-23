namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;

    public interface ICSVFileService
    {
        void WriteCSVFile(string path, RootCurrencieDTO[] root);
    }
}
