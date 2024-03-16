
using Business.Services;
using Dal.Repositories;
using DAL.Commons;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryCityController(
    ILogger<CountryCityController> logger,
    ICountryService countryService
    ) : ControllerBase{

        private readonly ILogger _logger = logger;

        private readonly ICountryService _countryService = countryService;
        
        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAndCities(int page =1, int pageCount = 25){
            var response = await _countryService.GetAllCountries(page, pageCount);
            return Ok(response);
        }
}
