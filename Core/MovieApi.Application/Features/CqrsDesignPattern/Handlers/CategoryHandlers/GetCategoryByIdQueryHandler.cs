using MovieApi.Application.Features.CqrsDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CqrsDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _context;
        public GetCategoryByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await _context.Categories.FindAsync(query.Id);
            if (category == null)
            {
                return null; 
            }
            return new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
