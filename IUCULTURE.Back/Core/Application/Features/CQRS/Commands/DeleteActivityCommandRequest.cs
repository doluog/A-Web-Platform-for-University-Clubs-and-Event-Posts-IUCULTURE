using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteActivityCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteActivityCommandRequest(int id)
        {
            Id = id;
        }
    }
}