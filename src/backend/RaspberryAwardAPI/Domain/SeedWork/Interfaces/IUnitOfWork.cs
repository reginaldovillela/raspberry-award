namespace RaspberryAwardAPI.Domain.SeedWork.Interfaces;

#pragma warning disable 1591
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}