using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class ProducersRepository(RaspberryAwardContext context) : IProducersRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<Producer> AddAsync(Producer producer, CancellationToken cancellationToken)
    {
        context.Entry(producer.Movies).State = EntityState.Unchanged;

        _ = await context.Producers.AddAsync(producer, cancellationToken);
        return producer;
    }

    public async Task<IEnumerable<Producer>> GetAllAsync(CancellationToken cancellationToken)
    {
        var producers = await context
            .Producers
            .Include(p => p.Movies)
            .OrderBy(p => p.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return producers;
    }

    public async Task<PagedList<Producer>> GetAllPagedAsync(ushort pageNumber, ushort pageSize, CancellationToken cancellationToken)
    {
        var totalRecords = context
           .Producers
           .CountAsync();

        var producers = context
            .Producers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(m => m.Movies)
            .OrderBy(m => m.Name)
            .AsNoTracking()
            .ToListAsync();

        await Task.WhenAll(totalRecords, producers);

        return new PagedList<Producer>(producers.Result,
                                       pageNumber,
                                       pageSize,
                                       (ushort)totalRecords.Result);
    }

    public async Task<IEnumerable<Producer>> GetAllAlreadyWinnerAsync(CancellationToken cancellationToken)
    {
        var producers = await context
            .Producers
            .Include(p => p.Movies.Where(m => m.Winner))
            .Where(p => p.Movies.Any(m => m.Winner))
            .OrderBy(p => p.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return producers;
    }
}