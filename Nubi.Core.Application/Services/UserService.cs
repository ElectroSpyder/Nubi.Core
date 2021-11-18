
namespace Nubi.Core.Application.Services
{
    using Nubi.Core.Application.DTO;
    using Nubi.Core.Application.Interfaces;
    using Nubi.Core.Application.Mappring;
    using Nubi.Core.Domain.Interfaces;
    using Nubi.Core.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> GetUser(int id)
        {
            var result = await _unitOfWork.UserRepository.GetById(id);
            if (result == null) return null;
            return new Response
            {
                StatudCode = true,
                Message = "Usuario encontrado",
                Result = EntityMapper.FromUserToUserDTO(result)
            };
        }

        public async Task<Response> GetAllUser()
        {
            var result = await _unitOfWork.UserRepository.GetAll();
            if (result == null) return new Response
            {
                StatudCode = false,
                Message = "No encontrado"
            };

            var listUserDTO = new List<UserDTO>();
            foreach (var item in result)
            {
                listUserDTO.Add(EntityMapper.FromUserToUserDTO(item));
            }
            return new Response
            {
                StatudCode = true,
                Result = listUserDTO,
                Message = "Listado de usuario"
            };
        }

        public async Task<Response> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result < 1) return new Response
            {
                StatudCode = false,
                Message = "Error"
            };
            return new Response
            {
                StatudCode = true,
                Message = "Borrado",
                Result = result
            };

        }

        public async Task<Response> UpdateUser(UserDTO userDTO, int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null) return new Response
            {
                StatudCode = false,
                Message = "Not found"
            };

            await _unitOfWork.UserRepository.Update(EntityMapper.FromUserDTOToUser(userDTO, user));
            var result = await _unitOfWork.SaveChangesAsync();
            if (result < 1) return new Response
            {
                StatudCode = false,
                Message = "Error"
            };
            return new Response
            {
                StatudCode = true,
                Message = "Actualizado",
                Result = result
            };
        }

        public async Task<Response> AddUser(UserDTO userDTO)
        {
            var existe = await _unitOfWork.UserRepository.GetSinglebyFound(x=> x.Email == userDTO.Email);
            if (existe != null) return new Response
            {
                StatudCode = true,
                Message = "Existe el usuario"
            };
            var user = new User();
            await _unitOfWork.UserRepository.Insert(EntityMapper.FromUserDTOToUser(userDTO, user));
            var result = await _unitOfWork.SaveChangesAsync();
            if (result < 1) return new Response
            {
                StatudCode = false,
                Message = "Error"
            };
            return new Response
            {
                StatudCode = true,
                Message = "Agregado",
                Result = result
            };
        }
    }
}
