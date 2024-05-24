using ECommerce.backend.Entities;
using ECommerce.backend.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : GenericController<Category>
    {
        public CategoryController(IGenericUnitOfWork<Category> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
