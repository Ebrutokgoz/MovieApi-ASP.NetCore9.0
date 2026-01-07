using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CqrsDesignPattern.Results.MovieResults
{
    internal class GetMovieByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ProductionYear { get; set; }
        public bool Status { get; set; }
    }
}
