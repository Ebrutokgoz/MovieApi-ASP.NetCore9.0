using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Commands.CategoryCommands
{
    public class DeleteCategoryCommand
    {
        public int Id { get; set; }
    }
}
