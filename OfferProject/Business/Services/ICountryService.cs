using Business.DTO;

namespace Business.Services;


public interface ICountryService{
    Task<BaseQueryResponseModel<QueryCountryResponseDTO>> GetAllCountries(int page = 1, int pageCount = 25);

}