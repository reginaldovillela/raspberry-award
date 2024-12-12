using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;
using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetMoviesQueryHandler(ILogger<GetMoviesQueryHandler> logger,
                                   IMoviesRepository repository) 
    : IRequestHandler<GetMoviesQuery, PagedResult<MovieSharedWithStudiosAndProducersDto>>
{
    public async Task<PagedResult<MovieSharedWithStudiosAndProducersDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await repository.GetAllPagedAsync(request.PageNumber, 
                                                       request.PageSize, 
                                                       cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", movies.Items.Count());

        return new PagedResult<MovieSharedWithStudiosAndProducersDto>(
            movies.Items.Select(m => 
                new MovieSharedWithStudiosAndProducersDto(m.EntityId,
                                                          m.Title,
                                                          m.Year,
                                                          m.Winner,
                                                          m.Studios.Select(s => new StudioSharedDto(s.EntityId, s.Name)),
                                                          m.Producers.Select(p => new ProducerSharedDto(p.EntityId, p.Name)))),
            movies.PageNumber, 
            movies.PageSize, 
            movies.TotalRecords);
    }
}