using Nubi.Core.Application.DTO;
using Nubi.Core.Domain.Models;
using System.Collections.Generic;

namespace Nubi.Core.Application.Mappring
{
    public static class EntityMapper
    {
        public static RootDTO FromRootToRootDTO(Root root, List<SearchDTO> searchDTO)
        {
            return new RootDTO
            {
                available_filters = root.available_filters,
                available_sorts = root.available_sorts,
                country_default_time_zone = root.country_default_time_zone,
                filters = root.filters,
                paging = root.paging,
                query = root.query,
                results = searchDTO,
                sort = root.sort,
                site_id = root.site_id
            };
        }
    }
}
