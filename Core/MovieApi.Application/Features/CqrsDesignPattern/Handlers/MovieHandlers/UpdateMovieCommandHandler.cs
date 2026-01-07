using MovieApi.Application.Features.CqrsDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.Id);
            if (movie != null)
            {
                movie.Title = command.Title;
                movie.CoverImageUrl = command.CoverImageUrl;
                movie.Rating = command.Rating;
                movie.Description = command.Description;
                movie.Duration = command.Duration;
                movie.ReleaseDate = command.ReleaseDate;
                movie.ProductionYear = command.ProductionYear;
                movie.Status = command.Status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
