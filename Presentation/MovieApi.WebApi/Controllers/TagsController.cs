using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var taglist = await _mediator.Send(new GetTagQuery());
            return Ok(taglist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Successfully Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new DeleteTagCommand(id));
            return Ok("Successfully Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Successfully Updated");
        }

        [HttpGet("GetTag")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(tag);
        }

    }
}
