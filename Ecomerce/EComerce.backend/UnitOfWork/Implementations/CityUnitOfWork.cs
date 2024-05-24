using EComerce.backend.Data;
using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Implementations;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.UnitOfWork.Interfaces;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Implementations
{
    public class CityUnitOfWork : GenericRepository<City>, ICityUnitOfWork
    {
        private readonly ICityRepository _cityUnitOfWork;

        public CityUnitOfWork(DataContext dataContext, ICityRepository cityUnitOfWork) : base(dataContext)
        {
            _cityUnitOfWork = cityUnitOfWork;
        }
        public override async Task<ActionResponse<IEnumerable<City>>> GetAllAsync(PaginationDTO pagination) => await _cityUnitOfWork.GetAllAsync(pagination);
        public override async Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination) => await _cityUnitOfWork.GetTotalPages(pagination);
    }
}
