using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IUCULTURE.Back.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClubsController (IMediator mediator)
        {
            this.mediator = mediator;
        }

      
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await mediator.Send(new GetAllClubsQueryRequest());
            return Ok(result);
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin,JuniorAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetClubQueryRequest(id));
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }


        [Authorize(Roles = "ExpertAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateClubCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [Authorize(Roles = "ExpertAdmin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateClubCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteClubCommandRequest(id));
            return Ok();
        }




    }
}
