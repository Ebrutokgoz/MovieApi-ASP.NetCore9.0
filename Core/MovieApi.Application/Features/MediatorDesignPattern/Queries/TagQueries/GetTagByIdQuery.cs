using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagByIdQuery: IRequest<GetTagByIdQueryResult>
    {
        public GetTagByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
