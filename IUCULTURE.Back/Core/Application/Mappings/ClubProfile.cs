using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Domain;

namespace IUCULTURE.Back.Core.Application.Mappings
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {

            this.CreateMap<Club, ClubListDto>().ReverseMap();
        }
    }
}