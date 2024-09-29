using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest<Unit>
    {

        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
