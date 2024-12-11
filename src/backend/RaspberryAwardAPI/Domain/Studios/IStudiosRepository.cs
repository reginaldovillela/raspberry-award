using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Studios;

#pragma warning disable 1591
public interface IStudiosRepository : IRepository<Studio>
{
    Task<ICollection<Studio>> GetStudiosAsync(CancellationToken cancellationToken);
}