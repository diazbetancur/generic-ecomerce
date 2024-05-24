using ECommerce.backend.Entities;
using ECommerce.backend.Repositories.Interfaces;
using ECommerce.backend.UnitOfWork.Interfaces;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Implementations
{
    public class CountryUnitOfWork : GenericUnitOfWork<Country>, ICountyUnitOfWork
    {
        private readonly ICountryRepository _countryRepository;
        public CountryUnitOfWork(IGenericRepository<Country> repository, ICountryRepository countryRepository) : base(repository)
        {
            _countryRepository = countryRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAllAsync() => await _countryRepository.GetAllAsync();

        public override async Task<ActionResponse<Country>> GetAsync(int Id) => await _countryRepository.GetAsync(Id);
    }
}
