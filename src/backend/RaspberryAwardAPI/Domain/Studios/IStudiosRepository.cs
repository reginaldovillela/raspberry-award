using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Studios;

#pragma warning disable 1591
public interface IProducersRepository : IRepository<Studio>
{
    Task<ICollection<Studio>> GetStudiosAsync();
}