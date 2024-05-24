using EComerce.backend.Data;
using ECommerce.backend.Dto;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.Utils.Helpers;
using ECommerce.backend.Utils.Responses;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }
        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _dataContext.Add(entity);
            try
            {
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T> 
                { 
                    Success = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int Id)
        {
            var row = await _dbSet.FindAsync(Id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    Message = "Registro no existe"
                };
            }
            try
            {
                _dbSet.Remove(row);
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true
                };
            }
            catch 
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    Message = "No se puede borrar porque el registro se esta usando."
                };
            }
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                Success = true,
                Result = await _dbSet.ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int Id)
        {
            var row = await _dbSet.FindAsync(Id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    Message = "Registro no existe"
                };
            }

            return new ActionResponse<T>
            {
                Success = true,
                Result = row
            };
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _dataContext.Update(entity);
            try
            {
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }
        private ActionResponse<T> ExceptionActionResponse(Exception ex)
        {
            return new ActionResponse<T>()
            {
                Success = false,
                Message = ex.Message,
            };
        }
        private ActionResponse<T> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<T>() 
            {  
                Success = false,
                Message = "Ya existe el registro que esta intentando crear"
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync(PaginationDTO pagination)
        {
            var queryable = _dbSet.AsQueryable();
            return new ActionResponse<IEnumerable<T>>
            {
                Success = true,
                Result = await queryable.Paginate(pagination).ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination)
        {
            var queryable = _dbSet.AsQueryable();
            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling( count / pagination.RecordsNumber);

            return new ActionResponse<int>
            {
                Success = true,
                Result = totalPages
            };
        }
    }
}
