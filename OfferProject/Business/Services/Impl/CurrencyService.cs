using Business.DTO;
using Core.Entities;
using DAL.Commons;
using DAL.Repositories;

namespace Business.Services;


public class CurrencyService(ICurrencyRepository currencyRepository) : ICurrencyService
{

    private readonly ICurrencyRepository _currencyRepository = currencyRepository;


    public async Task<BaseQueryResponseModel<Currency>> GetAllCurrencies(int page = 1, int pageCount = 25){
        var pagination = new Pagination(page, pageCount);
        var response = await _currencyRepository.GetAllAsync(c=>c.Id > 0, pagination);
        return new BaseQueryResponseModel<Currency>{
            Data = response.Data,
            Current = page,
            Pages = response.Pages,
            Total = response.Total
        };
    }

}