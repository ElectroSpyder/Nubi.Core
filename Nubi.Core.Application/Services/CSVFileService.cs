namespace Nubi.Core.Application.Services
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    public class CSVFileService : ICSVFileService
    {

        public void WriteCSVFile(string path, RootCurrencieDTO[] root)
        {
            var listSCV = new List<RootToSCV>();
            foreach (var item in root)
            {
                listSCV.Add(new RootToSCV
                {
                    id = item.id,
                    currency_base = item.todolar.currency_base,
                    creation_date = item.todolar.creation_date,
                    currency_quote = item.todolar.currency_quote,
                    decimal_places = item.decimal_places,
                    description = item.description,
                    inv_rate = item.todolar.inv_rate,
                    rate = item.todolar.rate,
                    ratio = item.todolar.ratio,
                    symbol = item.symbol,
                    valid_until = item.todolar.valid_until
                });
            }
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var sw = new StreamWriter(path, false, new UTF8Encoding(true));
            using var cw = new CsvWriter(sw, cc);

            cw.WriteHeader<RootToSCV>();
            cw.NextRecord();

            foreach (var item in listSCV)
            {


                cw.WriteRecord(item);

                cw.NextRecord();
            }

        }
    }

}
