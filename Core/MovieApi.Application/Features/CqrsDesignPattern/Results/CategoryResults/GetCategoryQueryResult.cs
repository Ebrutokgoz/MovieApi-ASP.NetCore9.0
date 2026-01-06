using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Results.CategoryResults
{
    internal class GetCategoryQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
