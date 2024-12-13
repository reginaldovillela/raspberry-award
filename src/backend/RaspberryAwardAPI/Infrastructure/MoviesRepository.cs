using RaspberryAwardAPI.Domain.Movies;
using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class MoviesRepository(RaspberryAwardContext context) : IMoviesRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Entry(movie.Studios).State = EntityState.Unchanged;
        context.Entry(movie.Producers).State = EntityState.Unchanged;

        _ = await context.Movies.AddAsync(movie, cancellationToken);
        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movies = await context
            .Movies
            .Include(m => m.Producers)
            .Include(m => m.Studios)
            .OrderBy(m => m.Title)
            .AsNoTracking()
            .ToListAsync();

        return movies;
    }

    public async Task<PagedList<Movie>> GetAllPagedAsync(ushort pageNumber,
                                                         ushort pageSize,
                                                         ushort? year,
                                                         bool? winner,
                                                         CancellationToken cancellationToken)
    {
        var totalRecords = context
            .Movies
            .Where(m => year == null || m.Year == year)
            .Where(m => winner == null || m.Winner == winner)
            .CountAsync();

        var movies = context
            .Movies
            .Where(m => year == null || m.Year == year)
            .Where(m => winner == null || m.Winner == winner)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(m => m.Producers)
            .Include(m => m.Studios)
            .OrderBy(m => m.Title)
            .AsNoTracking()
            .ToListAsync();

        await Task.WhenAll(totalRecords, movies);

        return new PagedList<Movie>(movies.Result,
            pageNumber,
            pageSize,
            (ushort)totalRecords.Result);
    }

    public async Task<IDictionary<ushort, ushort>> GetYearsWithWinnersAsync(CancellationToken cancellationToken)
    {
        var years = await context
            .Movies
            .Where(m => m.Winner)
            .GroupBy(m => m.Year)
            .AsNoTracking()
            .Select(y => new { year = y.Key, count = y.Count() })
            .ToDictionaryAsync(k => k.year, i => (ushort)i.count);

        return years;
    }
}