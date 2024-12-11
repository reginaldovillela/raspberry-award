namespace RaspberryAwardAPI.Domain.SeedWork.Interfaces;

#pragma warning disable 1591
/// <summary>
/// This interface is a base interface for any Entity Class and there're domain events
/// I followed MS Pattern with few changes
/// </summary>
/// <see href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces">MS Docs</see>
public interface IEntity
{
    void AddDomainEvent(INotification eventItem);

    void RemoveDomainEvent(INotification eventItem);

    void ClearDomainEvents();
};