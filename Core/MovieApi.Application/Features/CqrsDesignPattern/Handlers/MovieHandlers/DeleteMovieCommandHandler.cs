using MovieApi.Application.Features.CqrsDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.MovieHandlers
{
    public class DeleteMovieCommandHandler
    {
        private readonly MovieContext _context;

        public DeleteMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(DeleteMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.Id);
            //Movie movie = await _context.Movies.FindAsync(command.Id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
