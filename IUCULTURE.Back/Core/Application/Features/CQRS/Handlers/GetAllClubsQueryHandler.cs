using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllClubsQueryHandler : IRequestHandler<GetAllClubsQueryRequest, List<ClubListDto>>
    {
        private readonly IRepository<Club> repository;
        private readonly IMapper mapper;

        public GetAllClubsQueryHandler(IRepository<Club> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ClubListDto>> Handle(GetAllClubsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<ClubListDto>>(data);
            
        }
    }
}
