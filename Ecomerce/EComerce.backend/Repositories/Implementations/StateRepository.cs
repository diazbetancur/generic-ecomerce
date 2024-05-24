using EComerce.backend.Data;
using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.Utils.Helpers;
using ECommerce.backend.Utils.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.backend.Repositories.Implementations
{
    public class StateRepository : GenericRepository<State>, IStatesRepository
    {
        private readonly DataContext _db;

        public StateRepository(DataContext dataContext) : base(dataContext)
        {
            _db = dataContext;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAllAsync()
        {
            var states = await _db.States
                .OrderBy(s => s.Name)
                .Include(c => c.Cities)
                .ToListAsync();

            return new ActionResponse<IEnumerable<State>>()
            {
                Success = true,
                Result = states
            };
        }

        public override async Task<ActionResponse<State>> GetAsync(int Id)
        {
            var state = await _db.States
                .Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (state == null)
            {
                return new ActionResponse<State>()
                {
                    Success = false,
                    Message = "Departamento no existe."
                };
            }

            return new ActionResponse<State>()
            {
                Success = true,
                Result = state
            };
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAllAsync( PaginationDTO pagination)
        {
            var queryable = _db.States
                .Include(c => c.Cities)
                .Where(x => x.Country!.Id == pagination.Id)
                .AsQueryable();

            return new ActionResponse<IEnumerable<State>>()
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
            var queryable = _db.States
                .Where(x => x.Country!.Id == pagination.Id)
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
