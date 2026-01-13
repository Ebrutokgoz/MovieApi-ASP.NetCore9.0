using MovieApi.Application.Features.CqrsDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CqrsDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var movie = await _context.Movies.FindAsync(query.Id);
            if(movie == null)
            {
                return null;
            }
            return new GetMovieByIdQueryResult
            {
                Id = movie.Id,
                Title = movie.Title,
                CoverImageUrl = movie.CoverImageUrl,
                Rating = movie.Rating,
                Description = movie.Description,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                ProductionYear = movie.ProductionYear,
                Status = movie.Status
            };
        }
    }
}
