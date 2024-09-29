using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommandRequest, Unit>
    {
        private readonly IRepository<Activity> repository;

        public DeleteActivityCommandHandler(IRepository<Activity> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await this.repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
