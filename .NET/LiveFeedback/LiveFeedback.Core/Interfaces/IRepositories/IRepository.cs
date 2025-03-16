//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace LiveFeedback.Core.Interfaces.IRepositories

//{
//    public interface IRepository<T> where T : class
//    {
//        Task<T> GetByIdAsync(int id);
//        Task<IEnumerable<T>> GetAllAsync();
//        Task AddAsync(T entity);
//        Task UpdateAsync(T entity);
//        Task DeleteAsync(int id);
//    }
//}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveFeedback.Core.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id,T updatedEntity);
        Task DeleteAsync(int id);
    }
}

