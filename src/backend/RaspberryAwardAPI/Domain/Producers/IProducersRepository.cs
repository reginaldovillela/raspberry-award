using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.Producers;

#pragma warning disable 1591
public interface IProducersRepository : IRepository<Producer>
{
    Task<ICollection<Producer>> GetProducersAsync();
}