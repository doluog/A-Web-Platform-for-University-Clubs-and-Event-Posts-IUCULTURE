using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteClubCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteClubCommandRequest(int id)
        {
            Id = id;
        }
    }
}
