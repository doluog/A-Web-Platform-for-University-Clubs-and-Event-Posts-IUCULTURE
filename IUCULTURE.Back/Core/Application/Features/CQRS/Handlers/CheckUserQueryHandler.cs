using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Core.Application.Interfaces;
using IUCULTURE.Back.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x=> x.UserName ==
                request.UserName && x.Password == request.Password);

            if(user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilterAsync(x => x.Id ==
                user.AppRoleId);
                dto.Role = role?.Definition;

            }
            return dto;
        }
    }
}
