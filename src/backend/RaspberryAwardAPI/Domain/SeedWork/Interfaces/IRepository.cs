namespace RaspberryAwardAPI.Domain.SeedWork.Interfaces;

#pragma warning disable 1591
/// <summary>
/// This interface implements the Reposotiry Pattern. It's base to any repository
/// </summary>
/// <typeparam name="T">T must be an aggregate</typeparam>
/// <see href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces#repository-contracts-interfaces-in-the-domain-model-layer">MS Docs</see>
#pragma warning disable S2326 // Unused type parameters should be removed
public interface IRepository<T> where T : IAggregateRoot
#pragma warning restore S2326 // Unused type parameters should be removed
{
    IUnitOfWork UnitOfWork { get; }
}