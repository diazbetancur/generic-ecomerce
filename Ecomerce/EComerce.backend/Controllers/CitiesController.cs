using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.UnitOfWork.Implementations;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : GenericController<City>
    {
        private readonly ICityUnitOfWork _cityUnitOfWork;
        public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICityUnitOfWork cityUnitOfWork) : base(unitOfWork)
        {
            _cityUnitOfWork = cityUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _cityUnitOfWork.GetAllAsync(pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("TotalPages")]
        public override async Task<IActionResult> GetTotalPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _cityUnitOfWork.GetTotalPages(pagination);
            if (action.Success)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
