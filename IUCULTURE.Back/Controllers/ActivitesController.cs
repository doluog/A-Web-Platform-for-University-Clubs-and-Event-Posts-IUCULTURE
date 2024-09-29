using IUCULTURE.Back.Core.Application.Features.CQRS.Commands;
using IUCULTURE.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IUCULTURE.Back.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ActivitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
 
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await mediator.Send(new GetAllActivitiesQueryRequest());
            return Ok(result);
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin,JuniorAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetActivityQueryRequest(id));
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteActivityCommandRequest(id));
            return NoContent();
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin,JuniorAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateActivityCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }
        
      
      

    }
}