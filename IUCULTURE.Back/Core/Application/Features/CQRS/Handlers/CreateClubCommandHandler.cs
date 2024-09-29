using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{

    public class CreateClubCommandHandler : IRequestHandler<CreateClubCommandRequest, Unit>
    {
        private readonly IRepository<Club> repository;

        public CreateClubCommandHandler(IRepository<Club> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateClubCommandRequest request, CancellationToken cancellationToken)
        {
            var createdEntity = new Club
            {
                ClubName = request.ClubName,
                ClubLeaderName = request.ClubLeaderName,
                ClubType = request.ClubType,
                ClubDefinition = request.ClubDefinition,
                ClubDefinitionBold = request.ClubDefinitionBold,
            ClubImage = request.ClubImage,
            };
            await this.repository.CreateAsync(createdEntity);
            return Unit.Value;


        }

    }
}