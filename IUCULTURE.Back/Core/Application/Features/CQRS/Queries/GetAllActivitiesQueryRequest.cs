using IUCULTURE.Back.Core.Application.Dto;
using MediatR;
namespace IUCULTURE.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllActivitiesQueryRequest : IRequest<List<ActivityListDto>>
    {
        
    }
}
