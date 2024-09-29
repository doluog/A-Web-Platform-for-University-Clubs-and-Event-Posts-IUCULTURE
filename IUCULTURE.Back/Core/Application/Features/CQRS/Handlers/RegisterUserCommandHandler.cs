using IUCULTURE.Back.Core.Application.Enums;
using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, Unit>
    {
        private readonly IRepository<AppUser> repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var createdEntity = new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                AppRoleId = (int)RoleType.ExpertAdmin,
                
            };
            await this.repository.CreateAsync(createdEntity);
            return Unit.Value;
        }
    }
}
