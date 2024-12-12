using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Producers;

#pragma warning disable 1591
public interface IProducersRepository : IRepository<Producer>
{
    Task<Producer> AddAsync(Producer producer, CancellationToken cancellationToken);
    
    Task<IEnumerable<Producer>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<PagedList<Producer>> GetAllPagedAsync(ushort pageNumber, ushort pageSize, CancellationToken cancellationToken);

    Task<IEnumerable<Producer>> GetAllAlreadyWinnerAsync(CancellationToken cancellationToken);
}