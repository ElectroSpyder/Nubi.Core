namespace Nubi.Core.Domain.Interfaces
{
    using Nubi.Core.Domain.Models;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
