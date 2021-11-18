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

        public static UserDTO FromUserToUserDTO(User user)
        {
            return new UserDTO
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Email = user.Email
            };
        }

        public static User FromUserDTOToUser(UserDTO userDTO, User user)
        {
            user.Nombre = userDTO.Nombre == string.Empty ? user.Nombre: userDTO.Nombre;
            user.Apellido = userDTO.Apellido == string.Empty ? user.Apellido : userDTO.Apellido;
            user.Email = userDTO.Email == string.Empty ? user.Email : userDTO.Email;
            user.Password = userDTO.Password == string.Empty ? user.Password : User.ComputeSha256Hash(userDTO.Password);
            return user;
        }
    }
}
