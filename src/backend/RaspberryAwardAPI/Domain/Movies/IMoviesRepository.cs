using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Movies;

#pragma warning disable 1591

public interface IMoviesRepository : IRepository<Movie>
{
    Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken);

    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken);

    Task<PagedList<Movie>> GetAllPagedAsync(ushort pageNumber, ushort pageSize, CancellationToken cancellationToken);

    Task<IDictionary<ushort, ushort>> GetYearsWithWinnersAsync(CancellationToken cancellationToken);
}