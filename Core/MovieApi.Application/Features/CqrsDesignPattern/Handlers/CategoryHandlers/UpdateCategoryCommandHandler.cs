using MovieApi.Application.Features.CqrsDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.Id);
            if (category != null)
            {
                category.Name = command.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
