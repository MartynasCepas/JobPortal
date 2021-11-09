using AutoMapper;
using JobPortal.Data.Dtos.Applications;
using JobPortal.Data.Dtos.Auth;
using JobPortal.Data.Dtos.Responses;
using JobPortal.Data.Dtos.Topics;
using JobPortal.Data.Entities;

namespace JobPortal.Data
    
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<Offer, OfferDto>();
            CreateMap<CreateOfferDto, Offer>();
            CreateMap<UpdateOfferDto, Offer>();

            CreateMap<Response, ResponseDto>();
            CreateMap<CreateResposeDto, Response>();
            CreateMap<UpdateResponseDto, Response>();

            CreateMap<Application, ApplicationDto>();
            CreateMap<CreateApplicationDto, Application>();
            CreateMap<UpdateApplicationDto, Application>();

            CreateMap<User, UserDto>();
        }
    }
}
