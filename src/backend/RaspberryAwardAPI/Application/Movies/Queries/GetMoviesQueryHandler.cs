using RaspberryAwardAPI.Domain.Movies;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public class GetMoviesQueryHandler(ILogger<GetMoviesQueryHandler> logger,
                                   IMoviesRepository repository) : IRequestHandler<GetMoviesQuery, Movie[]>
{
    public async Task<Movie[]> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await repository.GetAllAsync( cancellationToken);
        
        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", movies.Count);
        
        return movies.ToArray();
    }
}