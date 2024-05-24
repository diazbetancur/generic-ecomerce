using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<ActionResponse<T>> AddAsync(T entity);
        Task<ActionResponse<T>> UpdateAsync(T entity);
        Task<ActionResponse<T>> DeleteAsync(int Id);
        Task<ActionResponse<T>> GetAsync(int Id);
        Task<ActionResponse<IEnumerable<T>>> GetAllAsync();
    }
}
