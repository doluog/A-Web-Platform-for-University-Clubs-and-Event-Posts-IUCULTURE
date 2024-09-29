using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Domain;

namespace IUCULTURE.Back.Core.Application.Mappings
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {

            this.CreateMap<Activity, ActivityListDto>().ReverseMap();
        }
    }
}