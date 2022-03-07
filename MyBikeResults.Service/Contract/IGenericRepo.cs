using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBikeResults.Service.Contract
{
    //This is a generic repository interface that has the most common methods that can be used
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        //Task<IAsyncEnumerable<T>> GetAllAsync();
        Task<T> Get(int id);
        Task<T> GetBy(object entity);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object entity);
        void Remove(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
