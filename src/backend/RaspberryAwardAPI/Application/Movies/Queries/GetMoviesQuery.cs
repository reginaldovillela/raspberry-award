using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Queries;
using RaspberryAwardAPI.Application.Shared.Results;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetMoviesQuery
    : PagedQuery,
        IRequest<PagedResult<MovieSharedWithStudiosAndProducersDto>>
{
    [FromQuery(Name = "year")] 
    public ushort? Year { get; init; }

    [FromQuery(Name = "winner")] 
    public bool? Winner { get; init; }
}