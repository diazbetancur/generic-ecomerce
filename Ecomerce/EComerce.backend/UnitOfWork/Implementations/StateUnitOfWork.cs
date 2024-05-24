using EComerce.backend.Data;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Implementations;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.UnitOfWork.Interfaces;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Implementations
{
    public class StateUnitOfWork : GenericRepository<State>, IStatesUnitOfWork
    {

        private readonly IStatesRepository _statesRepository;

        public StateUnitOfWork(DataContext dataContext, IStatesRepository statesRepository) : base(dataContext)
        {
            _statesRepository = statesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAllAsync() => await _statesRepository.GetAllAsync();

        public override async Task<ActionResponse<State>> GetAsync(int Id) => await _statesRepository.GetAsync(Id);
    }
}
