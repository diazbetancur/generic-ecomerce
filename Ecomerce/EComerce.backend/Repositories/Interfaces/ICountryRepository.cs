using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<ActionResponse<Country>> GetAsync(int Id);
        Task<ActionResponse<IEnumerable<Country>>> GetAllAsync();
        Task<ActionResponse<IEnumerable<Country>>> GetAllAsync(PaginationDTO pagination);
    }
}
