using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQueryRequest, List<ActivityListDto>>
    {
        private readonly IRepository<Activity> repository;
        private readonly IMapper mapper;

        public GetAllActivitiesQueryHandler(IRepository<Activity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ActivityListDto>> Handle(GetAllActivitiesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<ActivityListDto>>(data);
        }
    }
}