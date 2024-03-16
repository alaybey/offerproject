using Business.DTO;
using Core.Entities;
using Dal.Repositories;
using DAL.Commons;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    private readonly ICountryRepository _countryRepository = countryRepository;
    public async Task<BaseQueryResponseModel<QueryCountryResponseDTO>> GetAllCountries(int page = 1, int pageCount = 25){
        Pagination pagination = new(page, pageCount);
        var result = await _countryRepository.GetAllAsync(c=>c.Id > 0, pagination);
        var countries = await result.Data.Include(r=> r.Cities).ToListAsync();
        List<QueryCountryResponseDTO> response = [] ;
        foreach(var country in countries){
            ICollection<QueryCityResponseDTO> cities = [];  
            foreach(var city in country.Cities){
                cities.Add(new QueryCityResponseDTO
                {
                    Id = city.Id,
                    Name = city.Name
                });
            }
            response.Add(new QueryCountryResponseDTO{
                Id = country.Id,
                Name = country.Name,
                Cities = cities
            });
        }
        return new BaseQueryResponseModel<QueryCountryResponseDTO>
        {
            Data = response,
            Current = page,
            Pages = result.Pages,
            Total = result.Total
        };
    }

}

