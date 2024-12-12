using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Studios.Dtos;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public class GetTopWinnersStudiosQueryHandler(
    ILogger<GetTopWinnersStudiosQueryHandler> logger,
    IStudiosRepository repository) : IRequestHandler<GetTopWinnersStudiosQuery, IEnumerable<TopWinnerStudioDto>>
{
    public async Task<IEnumerable<TopWinnerStudioDto>> Handle(GetTopWinnersStudiosQuery request,
        CancellationToken cancellationToken)
    {
        var studios = await repository.GetAllHasMovieWinnerAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", studios.Count);

        return studios
            .OrderByDescending(s => s.Movies.Count)
            .ThenBy(s => s.Name)
            .Take(request.Limit)
            .Select(s => new TopWinnerStudioDto(
                s.EntityId,
                s.Name,
                (ushort)s.Movies.Count,
                request.IncludeMovies
                    ? s.Movies
                        .Select(m => new MovieSharedDto(
                            m.EntityId,
                            m.Title,
                            m.Year,
                            m.Winner))
                    : null));
    }
}