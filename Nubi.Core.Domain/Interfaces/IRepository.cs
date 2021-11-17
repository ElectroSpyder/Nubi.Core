namespace Nubi.Core.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    
        public interface IRepository<T>
        {
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(int id);
            Task Insert(T entity);
            Task Delete(int id);
            Task Update(T entity);           
        }
    
}
