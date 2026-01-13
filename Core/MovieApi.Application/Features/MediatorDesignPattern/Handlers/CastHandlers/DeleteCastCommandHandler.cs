using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand>
    {
        private readonly MovieContext _context;

        public DeleteCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.Id);
            if (cast != null)
            {
                _context.Casts.Remove(cast);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
