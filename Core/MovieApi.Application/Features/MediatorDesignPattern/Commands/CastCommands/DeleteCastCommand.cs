using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class DeleteCastCommand: IRequest
    {
        public DeleteCastCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
