
using Business.DTO;
using Core.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;



[ApiController]
[Route("[controller]")]
public class CurrencyController(ICurrencyRepository currencyRepository) : ControllerBase{

    private readonly ICurrencyRepository _currencyRepository = currencyRepository;



    [HttpGet]
    public async Task<IActionResult> GetAllCurrencies([FromQuery] int page=1, [FromQuery] int size=25){

        var response = new BaseQueryResponseModel<Currency>();
        
        var currencies = await _currencyRepository.GetAllAsync(c => true, new DAL.Commons.Pagination(page, size));
        response.Data = currencies.Data;
        response.Pages = currencies.Pages;
        response.Current= page;
        return Ok(response);
    }
}