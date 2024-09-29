using IUCULTURE.Back.Core.Application.Dto;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Queries
{
    public class GetClubQueryRequest : IRequest<ClubListDto>
    {
        public int Id { get; set; }

        public GetClubQueryRequest(int id)
        {
            Id = id;
        }
    }
}
