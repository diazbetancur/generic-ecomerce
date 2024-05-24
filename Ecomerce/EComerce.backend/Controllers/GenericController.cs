using ECommerce.backend.Dto;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : Controller where T : class
    {
        public readonly IGenericUnitOfWork<T> _unitOfWork;
        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("full")]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var action = await _unitOfWork.GetAllAsync();
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public virtual async Task<IActionResult> GetTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPages(pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAllAsync(pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.DeleteAsync(id);
            if (action.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
