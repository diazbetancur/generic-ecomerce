using EComerce.backend.Data;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.Utils.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.backend.Repositories.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext _db;
        public CountryRepository(DataContext dataContext) : base(dataContext)
        {
            _db = dataContext;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAllAsync()
        {
            var countries = await _db.Countries
                .Include(c => c.States)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Country>>()
            {
                Success = true,
                Result = countries
            };
        }

        public override async Task<ActionResponse<Country>> GetAsync(int Id)
        {
            var country = await _db.Countries
                .Include(c => c.States!)
                .ThenInclude(s => s.Cities)
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (country == null)
            {
                return new ActionResponse<Country>()
                {
                    Success = false,
                    Message = "Pais no existe."
                };
            }
            return new ActionResponse<Country>()
            {
                Success = true,
                Result = country
            };
        }
    }
}
