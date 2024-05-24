using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : GenericController<State>
    {
        private readonly IStatesUnitOfWork _statesUnitOfWork;

        public StateController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
        {
            _statesUnitOfWork = statesUnitOfWork;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _statesUnitOfWork.GetAsync(id);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAllAsync()
        {
            var action = await _statesUnitOfWork.GetAllAsync();
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _statesUnitOfWork.GetAllAsync(pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("TotalPages")]
        public override async Task<IActionResult> GetTotalPagesAsync( [FromQuery] PaginationDTO pagination )
        {
            var action = await _statesUnitOfWork.GetTotalPages( pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
