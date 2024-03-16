namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Business.DTO;
using Business.Services;

[ApiController]
[Route("[controller]")]
public class OfferController(IOfferService offerService, ILogger<OfferController>logger) : ControllerBase{
    private readonly IOfferService _offerService = offerService; 
    private readonly ILogger _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAllOffers([FromQuery] int page=1, [FromQuery] int size=25){
        
        BaseQueryResponseModel<QueryOfferResponseDTO> response;
        try{
            response = await _offerService.GetAllOffersAsync(page, size);
        } catch (Exception e){
            _logger.LogError("Error create: {}", e);
            return Ok(ApiResult<string>.Failure(e.Message));
        }
        return Ok(ApiResult<BaseQueryResponseModel<QueryOfferResponseDTO>>.Success(response));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnOffer(CreateOfferRequestDTO createOfferRequest){
        var response = await _offerService.CreateOfferAsync(createOfferRequest);
        return Ok(ApiResult<Guid>.Success(response));
    }
}