using EComerce.backend.Data;
using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Interfaces;
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
    }
}
