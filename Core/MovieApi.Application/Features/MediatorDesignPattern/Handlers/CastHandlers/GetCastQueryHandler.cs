using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var castList = await _context.Casts.AsNoTracking().ToListAsync();
            return castList.Select(cast => new GetCastQueryResult
            {
                Id = cast.Id,
                Title = cast.Title,
                Name = cast.Name,
                Surname = cast.Surname,
                ImageUrl = cast.ImageUrl,
                Overview = cast.Overview,
                Biography = cast.Biography
            }).ToList();
        }
    }
}
