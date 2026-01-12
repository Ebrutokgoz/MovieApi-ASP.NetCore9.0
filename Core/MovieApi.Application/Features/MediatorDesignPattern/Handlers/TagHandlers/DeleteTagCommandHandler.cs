using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly MovieContext _context;

        public DeleteTagCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(request.Id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
