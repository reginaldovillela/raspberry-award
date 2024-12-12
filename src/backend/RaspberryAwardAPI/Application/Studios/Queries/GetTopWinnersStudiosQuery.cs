using RaspberryAwardAPI.Application.Studios.Dtos;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public record GetTopWinnersStudiosQuery(ushort Limit = 3, bool IncludeMovies = false)
    : IRequest<IEnumerable<TopWinnerStudioDto>>;