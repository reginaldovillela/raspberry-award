using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Movies;

#pragma warning disable 1591

public interface IMoviesRepository : IRepository<Movie>
{
    Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken);
    
    Task<ICollection<Movie>> GetAllAsync(CancellationToken cancellationToken);
}