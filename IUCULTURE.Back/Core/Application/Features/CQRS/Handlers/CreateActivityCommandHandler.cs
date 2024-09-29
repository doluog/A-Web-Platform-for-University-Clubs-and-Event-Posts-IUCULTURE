using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommandRequest, Unit>
    {
        private readonly IRepository<Activity> repository;

        public CreateActivityCommandHandler(IRepository<Activity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var createdEntity = new Activity
            {
                ClubId = request.ClubId,
                ClubName = request.ClubName,
                ActivityName = request.ActivityName,
                ActivityDate = request.ActivityDate,
                ActivityType = request.ActivityType,
                ActivityDefinition = request.ActivityDefinition,
                ActivityDefinitionBold = request.ActivityDefinitionBold,
                ActivityImage = request.ActivityImage,
            };
            await this.repository.CreateAsync(createdEntity);
            return Unit.Value;
        }
    }
}
