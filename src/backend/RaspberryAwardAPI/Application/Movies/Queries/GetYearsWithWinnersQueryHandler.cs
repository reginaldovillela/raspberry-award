using RaspberryAwardAPI.Application.Movies.Dtos;
using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;
using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetYearsWithWinnersQueryHandler(ILogger<GetYearsWithWinnersQueryHandler> logger,
                                             IMoviesRepository repository)
    : IRequestHandler<GetYearsWithWinnersQuery, IEnumerable<YearSumWinnerDto>>
{
    public async Task<IEnumerable<YearSumWinnerDto>> Handle(GetYearsWithWinnersQuery request, CancellationToken cancellationToken)
    {
        var years = await repository.GetYearsWithWinnersAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", years.Count);

        return years
            .OrderByDescending(y => y.Value)
            .ThenBy(y=> y.Value)
            .Take(request.Limit)
            .Select(y => new YearSumWinnerDto(y.Key, y.Value));
    }
}