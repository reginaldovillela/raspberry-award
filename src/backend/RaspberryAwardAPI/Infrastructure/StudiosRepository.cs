using RaspberryAwardAPI.Domain.SeedWork.Interfaces;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Infrastructure;

#pragma warning disable 1591
public class StudiosRepository(RaspberryAwardContext context) : IStudiosRepository
{
    public IUnitOfWork UnitOfWork => context;

    public async Task<ICollection<Studio>> GetStudiosAsync(CancellationToken cancellationToken)
    {
        var studios = await context
            .Studios
            .OrderBy(s=> s.Name)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return studios;
    }
}
