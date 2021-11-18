namespace Nubi.Core.Infrastructure.Data.Repository
{
    using Nubi.Core.Domain.Interfaces;
    using Nubi.Core.Domain.Models;
    using Nubi.Core.Infrastructure.Data.Context;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsuarioDbContext _context;
        private IRepository<User> _usersRepository;

        public UnitOfWork(UsuarioDbContext context)
        {
            _context =  context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return _usersRepository ??= new Repository<User>(_context);
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }               

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
