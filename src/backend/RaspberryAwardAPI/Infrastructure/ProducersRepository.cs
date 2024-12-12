using RaspberryAwardAPI.Domain.Producers;
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

    public async Task<ICollection<Producer>> GetProducersAsync(CancellationToken cancellationToken)
    {
        var producers = await context
            .Producers
            .Include(p => p.Movies)
            .OrderBy(p => p.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return producers;
    }

    public async Task<ICollection<Producer>> GetProducersAlreadyWinnerAsync(CancellationToken cancellationToken)
    {
        var producers = context
            .Producers
            .Include(p => p.Movies)
            .Where(p => p.Movies.Any(m => m.Winner))
            .OrderBy(p => p.Name)
            .AsNoTracking();

        return await producers.Where(p => p.Movies.Count >= 2).ToListAsync(cancellationToken);
    }
}