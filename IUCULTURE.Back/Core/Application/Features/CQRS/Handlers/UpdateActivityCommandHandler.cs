using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommandRequest, Unit>
    {
        private readonly IRepository<Activity> repository;

        public UpdateActivityCommandHandler(IRepository<Activity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.ClubId = request.ClubId;
                updatedEntity.ClubName = request.ClubName;
                updatedEntity.ActivityName = request.ActivityName;
                updatedEntity.ActivityDate = request.ActivityDate;
                updatedEntity.ActivityType = request.ActivityType;
                updatedEntity.ActivityDefinition = request.ActivityDefinition;
                updatedEntity.ActivityDefinitionBold = request.ActivityDefinitionBold;
                updatedEntity.ActivityImage = request.ActivityImage;
                await this.repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
