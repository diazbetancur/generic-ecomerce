using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Interfaces
{
    public interface ICityUnitOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAllAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination);
    }
}
