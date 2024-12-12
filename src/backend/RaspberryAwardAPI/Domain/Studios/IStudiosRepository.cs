using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Studios;

#pragma warning disable 1591
public interface IStudiosRepository : IRepository<Studio>
{
    Task<Studio> AddAsync(Studio studio, CancellationToken cancellationToken);
    
    Task<ICollection<Studio>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<ICollection<Studio>> GetAllHasMovieWinnerAsync(CancellationToken cancellationToken);
}