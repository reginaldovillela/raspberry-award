using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Producers;

#pragma warning disable 1591
public interface IProducersRepository : IRepository<Producer>
{
    Task<Producer> AddAsync(Producer producer, CancellationToken cancellationToken);
    
    Task<ICollection<Producer>> GetProducersAsync(CancellationToken cancellationToken);
    
    Task<ICollection<Producer>> GetProducersAlreadyWinnerAsync(CancellationToken cancellationToken);
}