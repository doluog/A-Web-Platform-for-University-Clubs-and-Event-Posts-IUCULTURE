using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using IUCULTURE.Back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace IUCULTURE.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("{action}")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await this.mediator.Send(request);
            if(dto.IsExist)
            {
                
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }




    }
}

