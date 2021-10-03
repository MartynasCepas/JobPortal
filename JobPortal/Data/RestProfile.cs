using AutoMapper;
using JobPortal.Data.Dtos.Applications;
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
            CreateMap<ResponseDto, Response>();
            CreateMap<Response, CreateOfferDto>();
            CreateMap<Response, UpdateOfferDto>();

            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, CreateApplicationDto>();
            CreateMap<Application, UpdateApplicationDto>();
        }
    }
}
