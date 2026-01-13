using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CqrsDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(movies => new GetMovieQueryResult
            {
                Id = movies.Id,
                Title = movies.Title,
                CoverImageUrl = movies.CoverImageUrl,
                Rating = movies.Rating,
                Description = movies.Description,
                Duration = movies.Duration,
                ReleaseDate = movies.ReleaseDate,
                ProductionYear = movies.ProductionYear,
                Status = movies.Status
            }).ToList();
        }
    }
}
