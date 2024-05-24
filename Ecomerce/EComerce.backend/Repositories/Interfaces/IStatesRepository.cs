using ECommerce.backend.Entities;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.Repositories.Interfaces
{
    public interface IStatesRepository
    {
        Task<ActionResponse<State>> GetAsync(int Id);
        Task<ActionResponse<IEnumerable<State>>> GetAllAsync();
    }
}
