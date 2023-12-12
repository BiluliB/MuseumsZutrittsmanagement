using AutoMapper;
using APIWebApplication.Models;
using APIWebApplication.DTO.Response;
using APIWebApplication.DTO.Request;

namespace APIWebApplication.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            //Responses
            CreateMap<AccessLog, AccessLogResponse>();
            CreateMap<MuseumArea, MuseumAreaResponse>();
            CreateMap<OpeningHour, OpeningHourResponse>();
            CreateMap<VisitorCapacity, VisitorCapacityResponse>();

            // Requests
            CreateMap<CreateAccessLogRequest, AccessLog>();
            CreateMap<UpdateAccessLogRequest, AccessLog>();

            CreateMap<CreateMuseumAreaRequest, MuseumArea>();
            CreateMap<UpdateMuseumAreaRequest, MuseumArea>();

            CreateMap<CreateOpeningHourRequest, OpeningHour>();
            CreateMap<UpdateOpeningHourRequest, OpeningHour>();

            CreateMap<CreateVisitorCapacityRequest, VisitorCapacity>();
            CreateMap<UpdateVisitorCapacityRequest, VisitorCapacity>();


        }
    }
}
