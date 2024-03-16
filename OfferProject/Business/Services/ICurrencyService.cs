using Business.DTO;
using Core.Entities;

namespace Business.Services;

public interface ICurrencyService {

        Task<BaseQueryResponseModel<Currency>> GetAllCurrencies(int page = 1, int pageCount = 25);

}