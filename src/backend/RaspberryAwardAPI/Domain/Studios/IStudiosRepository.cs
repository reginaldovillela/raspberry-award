using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Studios;

#pragma warning disable 1591
public interface IStudiosRepository : IRepository<Studio>
{
    Task<Studio> AddAsync(Studio studio, CancellationToken cancellationToken);
    
    Task<IEnumerable<Studio>> GetAllAsync(CancellationToken cancellationToken);

    Task<PagedList<Studio>> GetAllPagedAsync(ushort pageNumber, ushort pageSize, CancellationToken cancellationToken);
    
    Task<IEnumerable<Studio>> GetAllAlreadyWinnerAsync(CancellationToken cancellationToken);
}