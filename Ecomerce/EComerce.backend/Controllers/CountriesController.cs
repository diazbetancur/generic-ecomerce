using ECommerce.backend.Entities;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : GenericController<Country>
    {
        public CountriesController( IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork) { }
    }
}
