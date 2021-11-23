namespace Nubi.Core.Application.Services
{
    using Newtonsoft.Json;
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using static Nubi.Core.Application.DTO.RootCurrencieDTO;

    public class CurrencieService : ICurrencie
    {
        private readonly IApiServices _apiServices;
        private readonly ICSVFileService _cSVFileService;
        public CurrencieService(IApiServices apiServices, ICSVFileService cSVFileService)
        {
            _apiServices = apiServices;
            _cSVFileService = cSVFileService;
        }

        public async Task<ResponseWeb> GetDataFromNubimetric()
        {
            try
            {

                var currencies = await GetCurrencie();

                if (string.IsNullOrEmpty(currencies))
                    return new ResponseWeb
                    {
                        Message = "error ",
                        StatudCode = false,
                        Result = null
                    };

                var root = JsonConvert.DeserializeObject<RootCurrencieDTO[]>(currencies);

                if (!root.Any())
                    return new ResponseWeb
                    {
                        Message = "error en la segunda llamada",
                        StatudCode = false,
                        Result = null
                    };

                foreach (var item in root)
                {
                    var result = await GetCurrencyConversions(item.id);
                    var todolar = JsonConvert.DeserializeObject<ToDolar>(result);
                    if (todolar == null)
                    {

                        item.todolar = new ToDolar
                        {
                            creation_date = DateTime.Now.ToShortDateString(),
                            currency_base = item.id,
                            currency_quote = "USD",
                            inv_rate = 0,
                            rate = "0",
                            ratio = "0",
                            valid_until = DateTime.Now.ToShortDateString()
                        };
                    }
                    else
                    {
                        item.todolar = todolar;
                    }


                }
                return new ResponseWeb
                {
                    StatudCode = true,
                    Message = "Datos obtenidos",
                    Result = root
                };
            }
            catch (Exception ex)
            {
                return new ResponseWeb
                {
                    StatudCode = false,
                    Message = ex.Message
                };
            }
        }

        private async Task<string> GetCurrencie()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var result = await _apiServices.GetAsync("/currencies/", null, token);
            return result;
        }

        private async Task<string> GetCurrencyConversions(string id)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var result = await _apiServices.GetAsync("/currency_conversions/search?from=" + id, "&to=USD", token);
            return result;
        }

        public async Task<ResponseWeb> WriteJson(RootCurrencieDTO[] root)
        {
            try
            {
               
                var rootFolder = Directory.GetCurrentDirectory();
                
                FileStream fileStream = new(Path.Combine(rootFolder, "wwwroot", "Json", "current.json"), FileMode.Open, FileAccess.ReadWrite);
                using StreamWriter file =
                    new(fileStream);
                foreach (var item in root)
                {
                    var json = JsonConvert.SerializeObject(item);
                    file.WriteLine(json);
                }
                
                return new  ResponseWeb
                {
                    StatudCode = true,
                    Message = "Se creo el archivo en disco",
                     Result = null,
                };

            }
            catch (Exception ex)
            {
                return new ResponseWeb
                {
                    StatudCode = false,
                    Message = ex.Message
                };
            }
        }

        public bool WriteSCVFile(RootCurrencieDTO[] root)
        {
            try
            {
                var rootFolder = Directory.GetCurrentDirectory();

                var path = Path.Combine(rootFolder, "wwwroot", "csv", "current.csv");

                _cSVFileService.WriteCSVFile(path, root);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
