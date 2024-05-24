using EComerce.backend.Data;
using ECommerce.backend.Entities;

namespace ECommerce.backend.Data
{
    public class Seedb
    {
        private readonly DataContext _dataContext;
        public Seedb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CeckCountriesAsyc();
            await CeckCategoriesAsyc();
        }

        private async Task CeckCategoriesAsyc()
        {
            if (!_dataContext.Categories.Any())
            {
                _dataContext.Categories.Add(new Category { Name = "Pizzas" });
                _dataContext.Categories.Add(new Category { Name = "Alitas" });
                _dataContext.Categories.Add(new Category { Name = "Adiciones" });
                _dataContext.Categories.Add(new Category { Name = "Hamburguesas" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CeckCountriesAsyc()
        {
            if (!_dataContext.Countries.Any())
            {
                _dataContext.Countries.Add( new Country 
                { 
                    Name = "Honduras",
                    States = 
                    [
                        new()
                        {
                            Name = "Francisco Morazán",
                            Cities =
                            [
                            new() { Name = "Tegucigalpa"}
                            ]
                        },
                        new()
                        {
                            Name = "La Paz",
                            Cities =
                            [
                                new() { Name = "La Paz" }
                            ]
                        },
                        new()
                        {
                            Name = "Olancho",
                            Cities =
                            [
                                new() { Name = "Juticalpa" }
                            ]
                        }
                    ]
                } );
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
