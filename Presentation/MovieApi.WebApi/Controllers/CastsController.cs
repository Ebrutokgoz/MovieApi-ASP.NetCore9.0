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
        public IActionResult CastList()
        {
            var castList = _mediator.Send(new GetCastQuery());
            return Ok(castList);
        }

        [HttpPost]
        public IActionResult CreateCast(CreateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Successfully Added");
        }

        [HttpDelete]
        public IActionResult DeleteCast(int id)
        {
            _mediator.Send(new DeleteCastCommand(id));
            return Ok("Successfully Deleted");
        }

        [HttpPut]
        public IActionResult UpdateCast(UpdateCastCommand command)
        {
            _mediator.Send(command);
            return Ok("Successfully Updated");
        }

        [HttpGet("GetCast")]
        public IActionResult GetCast(int id)
        {
            var cast = _mediator.Send(new GetCastByIdQuery(id));
            return Ok(cast);
        }
    }
}
