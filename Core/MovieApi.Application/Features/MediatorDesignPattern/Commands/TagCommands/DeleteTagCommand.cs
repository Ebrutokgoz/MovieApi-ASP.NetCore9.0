using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class DeleteTagCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteTagCommand(int id)
        {
            Id = id;
        }
    }
}
