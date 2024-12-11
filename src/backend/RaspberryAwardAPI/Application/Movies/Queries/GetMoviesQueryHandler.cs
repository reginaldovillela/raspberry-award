using RaspberryAwardAPI.Application.Movies.Dtos;
using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetMoviesQueryHandler(ILogger<GetMoviesQueryHandler> logger,
                                   IMoviesRepository repository) : IRequestHandler<GetMoviesQuery, MovieDto[]>
{
    public async Task<MovieDto[]> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await repository.GetAllAsync(cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", movies.Count);
        
        return movies.Select(m =>
            new MovieDto(m.EntityId,
                         m.Title,
                         m.Year,
                         m.Winner,
                         m.Studios.Select(s => new StudioDto(s.EntityId, s.Name)).ToList(),
                         m.Producers.Select(p => new ProducerDto(p.EntityId, p.Name)).ToList()
                         )).ToArray();


    }
}