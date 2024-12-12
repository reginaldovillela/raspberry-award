using RaspberryAwardAPI.Application.Studios.Dtos;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public class GetTopWinnersStudiosQuery
    : IRequest<IEnumerable<TopWinnerStudioDto>>
{
    [DefaultValue(1)]
    [FromQuery(Name = "limit")]
    public ushort Limit { get; init; } = 3;

    [DefaultValue(false)]
    [FromQuery(Name = "includeMovies")]
    public bool IncludeMovies { get; init; } = false;
}