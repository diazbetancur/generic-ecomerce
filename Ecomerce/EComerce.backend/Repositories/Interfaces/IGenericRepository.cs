using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ActionResponse<T>> AddAsync(T entity);
        Task<ActionResponse<T>> UpdateAsync(T entity);
        Task<ActionResponse<T>> DeleteAsync(int Id);
        Task<ActionResponse<T>> GetAsync(int Id);
        Task<ActionResponse<IEnumerable<T>>> GetAllAsync(); 
    }
}
