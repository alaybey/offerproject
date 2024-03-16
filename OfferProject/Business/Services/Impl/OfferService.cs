
using AutoMapper;
using Business.DTO;
using DAL.Repositories;
using DAL.Commons;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Business.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class OfferService(
    IOfferRepository offerRepository,
    IMapper mapper,
    ILogger<OfferService> logger,
    ICurrencyRepository currencyRepository
    ) : IOfferService
{
    private readonly ILogger _logger = logger;
    private readonly IMapper _mapper = mapper;
    private readonly IOfferRepository _offerRepository = offerRepository;
    private readonly ICurrencyRepository _currencyRepository = currencyRepository;

    public async Task<Guid> CreateOfferAsync(CreateOfferRequestDTO createOfferRequest)
    {

        var currency = await _currencyRepository.GetFirstAsync(c => c.Code.Equals(createOfferRequest.Currency));
        Offer offer = new()
        {
            ModeId = createOfferRequest.Mode,
            CountryId = createOfferRequest.Country,
            CityId = createOfferRequest.City,
            CurrencyId = currency.Id,
            Currency = currency,
            PackageTypeId = createOfferRequest.PackageType,
            Incoterm = createOfferRequest.Incoterms.ToString(),
            MovementType = createOfferRequest.MovementType.ToString(),
            Unit1 = createOfferRequest.Unit1.ToString(),
            Unit2 = createOfferRequest.Unit2.ToString(),
            CreatedBy = "client",
            Id = Guid.NewGuid()
        };
        try
        { 
            await _offerRepository.AddAsync(offer);
            _logger.LogInformation("New offer record saved. Id: {}", offer.Id);
        } catch (Exception e){
            _logger.LogError("{M}. Date: {DT}", e.GetType().ToString(), DateTime.UtcNow.ToLongTimeString());
            throw new DbSaveExceptions("Error when creating a new offer");
        }
        return offer.Id;
    }

    public async Task<BaseQueryResponseModel<QueryOfferResponseDTO>> GetAllOffersAsync(int page = 1, int pageCount = 25){
        if(page < 1 || pageCount < 1){
            throw new Exception("Please input possitive numbers to pagination.");
        }
        Pagination pagination = new(page, pageCount);

        var offers = await _offerRepository.GetAllAsync(o => o.IsDeleted == false, pagination);
        //List<QueryOfferResponseDTO> response = new List<QueryOfferResponseDTO>(); 
        var offerList = await offers.Data
        .Include(r => r.Country)
        .ThenInclude(r => r.Cities)
        .Include(r => r.Currency)
        .Include(r => r.Mode)
        .Include(r => r.PackageType)
        .ToListAsync();
        /*foreach(var offer in offers.Data){
            response.Add(new QueryOfferResponseDTO
            {
                Id = offer.Id,
                City = offer.City?.Name ?? "",
                Country = offer.Country?.Name ?? "",
                Currency = offer.Currency.Code,
                Mode = offer.Mode?.Value ?? "",
                Incoterms = offer.Incoterm ?? "",
                MovementType = offer.MovementType,
                PackageType = offer.PackageType?.Value ?? "",
                CreatedBy = offer.CreatedBy,
                Unit1 = offer.Unit1,
                Unit2 = offer.Unit2,
                UpdatedBy = offer.UpdatedBy ?? ""
            });
        }
            */
        var response = _mapper.Map<List<QueryOfferResponseDTO>>(offerList);
        
        return new BaseQueryResponseModel<QueryOfferResponseDTO>{
            Data = response,
            Current = page,
            Pages = offers.Pages,
            Total = offers.Total
        };
    }
}