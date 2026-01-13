using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Commands.MovieCommands
{
    public class DeleteMovieCommand
    {
        public DeleteMovieCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
