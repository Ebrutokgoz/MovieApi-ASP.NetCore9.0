using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CqrsDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CqrsDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CqrsDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly DeleteMovieCommandHandler _deleteMovieCommanHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQuerHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;

        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler, DeleteMovieCommandHandler deleteMovieCommanHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQuerHandler, UpdateMovieCommandHandler updateMovieCommandHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _deleteMovieCommanHandler = deleteMovieCommanHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQuerHandler = getMovieQuerHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var movieList = await _getMovieQuerHandler.Handle();
            return Ok(movieList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Successfully Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id) 
        {
            await _deleteMovieCommanHandler.Handle(new DeleteMovieCommand(id));
            return Ok("Successfully Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Successfully Updated");
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(movie);
        }
    }
}
