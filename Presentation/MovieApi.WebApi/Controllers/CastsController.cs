using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CastList()
        {
            var castList = await _mediator.Send(new GetCastQuery());
            return Ok(castList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Successfully Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
            await _mediator.Send(new DeleteCastCommand(id));
            return Ok("Successfully Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Successfully Updated");
        }

        [HttpGet("GetCast")]
        public async Task<IActionResult> GetCast(int id)
        {
            var cast = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(cast);
        }
    }
}
