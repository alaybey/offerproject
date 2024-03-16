using AutoMapper;
using Business.DTO;
using Core.Entities;

namespace Business.MappingProfiles;

public class OfferProfile : Profile{

    public OfferProfile(){
        CreateMap<Offer, QueryOfferResponseDTO>()
        .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
        .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
        .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code))
        .ForMember(dest => dest.PackageType, opt => opt.MapFrom(src => src.PackageType.Value))
        .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode.Value));
        CreateMap<CreateOfferRequestDTO, Offer>();
    }
}