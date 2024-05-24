using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<ActionResponse<IEnumerable<City>>> GetAllAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination);
    }
}
