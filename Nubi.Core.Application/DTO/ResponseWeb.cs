namespace Nubi.Core.Application.DTO
{
    public class ResponseWeb
    {
        public bool StatudCode { get; set; }
        public string Message { get; set; }
        public RootCurrencieDTO[] Result { get; set; }
    }
}
