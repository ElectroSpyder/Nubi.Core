using Nubi.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nubi.Core.Application.DTO
{
    public class RootDTO
    {
        
            public string site_id { get; set; }
            public string country_default_time_zone { get; set; }
            public string query { get; set; }
            public Paging paging { get; set; }
            public List<SearchDTO> results { get; set; }
            public Sort sort { get; set; }
            public List<AvailableSort> available_sorts { get; set; }
            public List<Filter> filters { get; set; }
            public List<AvailableFilter> available_filters { get; set; }
       
    }
}
