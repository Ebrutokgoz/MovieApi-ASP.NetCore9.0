using MovieApi.Application.Features.CqrsDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public DeleteCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.Id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
