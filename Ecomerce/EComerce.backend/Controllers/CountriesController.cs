using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : GenericController<Country>
    {
        private readonly ICountyUnitOfWork _countyUnitOfWork;
        public CountriesController( IGenericUnitOfWork<Country> unitOfWork, ICountyUnitOfWork countyUnitOfWork) : base(unitOfWork)
        {
            _countyUnitOfWork = countyUnitOfWork;
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _countyUnitOfWork.GetAsync(id);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAllAsync()
        {
            var action = await _countyUnitOfWork.GetAllAsync();
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _countyUnitOfWork.GetAllAsync();
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
