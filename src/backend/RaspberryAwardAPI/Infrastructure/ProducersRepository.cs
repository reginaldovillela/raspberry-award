using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class ProducersRepository(RaspberryAwardContext context) : IProducersRepository
{
    public IUnitOfWork UnitOfWork => context;

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
}
