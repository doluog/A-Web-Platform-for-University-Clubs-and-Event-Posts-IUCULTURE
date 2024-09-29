using AutoMapper;
using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetClubQueryHandler : IRequestHandler<GetClubQueryRequest, ClubListDto>
    {
        private readonly IRepository<Club> repository;
        private readonly IMapper mapper;

        public GetClubQueryHandler(IRepository<Club> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ClubListDto> Handle(GetClubQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<ClubListDto>(data);
        }
    }
}
