using Business.DTO;

namespace Business.Services;

public interface IOfferService{
    Task<BaseQueryResponseModel<QueryOfferResponseDTO>> GetAllOffersAsync(int page, int size);

    Task<Guid> CreateOfferAsync(CreateOfferRequestDTO createOfferRequest);

}