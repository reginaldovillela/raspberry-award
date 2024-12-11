using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class MoviesRepository(RaspberryAwardContext context) : IMoviesRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        //_ = await context.AddAsync(movie, cancellationToken);
        _ = await context.Movies.AddAsync(movie, cancellationToken);
        return movie; 
    }

    public async Task<ICollection<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movies = await context
            .Movies
            .OrderBy(m => m.Title)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return movies;
    }
}