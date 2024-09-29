using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommandRequest, Unit>
    {
        private readonly IRepository<Club> repository;

        public UpdateClubCommandHandler(IRepository<Club> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateClubCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.ClubName = request.ClubName;
                updatedEntity.ClubLeaderName = request.ClubLeaderName;
                updatedEntity.ClubType = request.ClubType;
                updatedEntity.ClubDefinition = request.ClubDefinition;
                updatedEntity.ClubDefinitionBold = request.ClubDefinitionBold;
                updatedEntity.ClubImage = request.ClubImage;
                await this.repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
