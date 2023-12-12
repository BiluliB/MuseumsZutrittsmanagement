using AutoMapper;
using APIWebApplication.Models;
using APIWebApplication.DTO.Response;

namespace APIWebApplication.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<AccessLog, AccessLogDTO>();
            CreateMap<MuseumArea, MuseumAreaDTO>();
            CreateMap<OpeningHour, OpeningHourDTO>();
            CreateMap<VisitorCapacity, AccessLogDTO>();


        }
    }
}
