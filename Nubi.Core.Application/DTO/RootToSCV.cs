using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nubi.Core.Application.DTO
{
    public class RootToSCV
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string decimal_places { get; set; }
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public string ratio { get; set; }
        public string rate { get; set; }
        public long inv_rate { get; set; }
        public string creation_date { get; set; }
        public string valid_until { get; set; }

    }
}
