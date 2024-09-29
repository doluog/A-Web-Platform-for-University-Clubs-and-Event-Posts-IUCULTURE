using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetActivityQueryHandler : IRequestHandler<GetActivityQueryRequest, ActivityListDto>
    {
        private readonly IRepository<Activity> repository;
        private readonly IMapper mapper;

        public GetActivityQueryHandler(IRepository<Activity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ActivityListDto> Handle(GetActivityQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<ActivityListDto>(data);
        }
    }
}
