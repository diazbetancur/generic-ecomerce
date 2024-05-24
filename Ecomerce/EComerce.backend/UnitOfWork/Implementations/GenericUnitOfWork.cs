using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.UnitOfWork.Interfaces;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<ActionResponse<T>> AddAsync(T entity) => await _repository.AddAsync(entity);


        public virtual async Task<ActionResponse<T>> DeleteAsync(int Id) => await _repository.DeleteAsync(Id);

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<ActionResponse<T>> GetAsync(int Id) => await _repository.GetAsync(Id);

        public async Task<ActionResponse<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    }
}
