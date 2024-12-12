using RaspberryAwardAPI.Domain.SeedWork.Interfaces;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class StudiosRepository(RaspberryAwardContext context) : IStudiosRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Studio> AddAsync(Studio studio, CancellationToken cancellationToken)
    {
        _ = await context.Studios.AddAsync(studio, cancellationToken);
        return studio;
    }

    public async Task<ICollection<Studio>> GetAllAsync(CancellationToken cancellationToken)
    {
        var studios = await context
            .Studios
            .OrderBy(s => s.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return studios;
    }

    public async Task<ICollection<Studio>> GetAllHasMovieWinnerAsync(CancellationToken cancellationToken)
    {
        var studios = await context
            .Studios
            .Include(s => s.Movies.Where(m => m.Winner))
            .Where(s => s.Movies.Any(m => m.Winner))
            .OrderBy(s => s.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return studios;
    }
}