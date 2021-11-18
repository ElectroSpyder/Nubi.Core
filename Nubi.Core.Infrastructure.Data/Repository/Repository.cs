namespace Nubi.Core.Infrastructure.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Nubi.Core.Domain.Interfaces;
    using Nubi.Core.Domain.Models;
    using Nubi.Core.Infrastructure.Data.Context;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly UsuarioDbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(UsuarioDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            entity.IsDeleted = true;
            _entities.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _entities.FindAsync(id);
            return entity;
        }

        public async Task Insert(T entity)
        {
            entity.CreatedAt = DateTime.Now;

            entity.IsDeleted = false;

            await _entities.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
