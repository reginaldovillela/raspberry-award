using RaspberryAwardAPI.Application.Movies.Dtos;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetYearsWithWinnersQuery
    : IRequest<IEnumerable<YearSumWinnerDto>>
{
    [DefaultValue(1)]
    [FromQuery(Name = "limit")]
    public ushort Limit { get; init; } = 3;
}