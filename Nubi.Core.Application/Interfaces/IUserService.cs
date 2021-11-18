namespace Nubi.Core.Application.Interfaces
{
    using Nubi.Core.Application.DTO;
    using System.Threading.Tasks;
    public interface IUserService
    {
        Task<Response> GetUser(int id);
        Task<Response> GetAllUser();
        Task<Response> DeleteUser(int id);
        Task<Response> UpdateUser(UserDTO userDTO, int id);
        Task<Response> AddUser(UserDTO userDTO);
    }
}
