using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{

    public class DeleteClubCommandHandler : IRequestHandler<DeleteClubCommandRequest, Unit>
    {
        private readonly IRepository<Club> repository;

        public DeleteClubCommandHandler(IRepository<Club> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteClubCommandRequest request, CancellationToken cancellationToken)
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
