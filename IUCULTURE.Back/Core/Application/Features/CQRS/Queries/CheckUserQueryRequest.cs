using IUCULTURE.Back.Core.Application.Dto;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
