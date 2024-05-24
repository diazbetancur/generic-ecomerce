using EComerce.backend.Data;
using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.Utils.Helpers;
using ECommerce.backend.Utils.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.backend.Repositories.Implementations
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly DataContext _db;

        public CityRepository(DataContext dataContext) : base(dataContext)
        {
            _db = dataContext;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAllAsync(PaginationDTO pagination)
        {
            var queryable = _db.Cities
                .Where(x => x.State!.Id == pagination.Id)
                .AsQueryable();
            
            return new ActionResponse<IEnumerable<City>>()
            {
                Success = true,
                Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination)
        {
            var queryable = _db.Cities
                .Where(x => x.State!.Id == pagination.Id)
                .AsQueryable();
            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);

            return new ActionResponse<int>
            {
                Success = true,
                Result = totalPages
            };
        }
    }
}
