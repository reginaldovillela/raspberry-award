using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class StudiosRepository(RaspberryAwardContext context) : IStudiosRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Studio> AddAsync(Studio studio, CancellationToken cancellationToken)
    {
        context.Entry(studio.Movies).State = EntityState.Unchanged;

        _ = await context.Studios.AddAsync(studio, cancellationToken);
        return studio;
    }

    public async Task<IEnumerable<Studio>> GetAllAsync(CancellationToken cancellationToken)
    {
        var studios = await context
            .Studios
            .OrderBy(s => s.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return studios;
    }

    public async Task<PagedList<Studio>> GetAllPagedAsync(ushort pageNumber, ushort pageSize, CancellationToken cancellationToken)
    {
        var totalRecords = context
           .Studios
           .CountAsync();

        var studios = context
            .Studios
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(m => m.Movies)
            .OrderBy(m => m.Name)
            .AsNoTracking()
            .ToListAsync();

        await Task.WhenAll(totalRecords, studios);

        return new PagedList<Studio>(studios.Result,
                                     pageNumber,
                                     pageSize,
                                     (ushort)totalRecords.Result);
    }

    public async Task<IEnumerable<Studio>> GetAllAlreadyWinnerAsync(CancellationToken cancellationToken)
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