using IUCULTURE.Back.Core.Application.Dto;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Queries
{
    public class GetActivityQueryRequest : IRequest<ActivityListDto>
    {
        public int Id { get; set; }
        
        public GetActivityQueryRequest(int id)
        {
            Id = id;   
        }
    }
}
