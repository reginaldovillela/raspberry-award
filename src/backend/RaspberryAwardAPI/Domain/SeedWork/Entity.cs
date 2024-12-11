using System.ComponentModel.DataAnnotations.Schema;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;

namespace RaspberryAwardAPI.Domain.SeedWork;

#pragma warning disable 1591
/// <summary>
/// This class implements the Entity Pattern. It's used to identify and extend other classes as an entity
/// I followed MS Pattern with few changes
/// </summary>
/// <see href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces#the-custom-entity-base-class">MS Docs</see>
public abstract class Entity : IEntity
{
    int? _requestedHashCode;

    private List<INotification> _domainEvents;

    [Key]
    [Column("Id")]
    [JsonPropertyName("id")]
    public virtual Guid EntityId { get; protected set; }
    
    [NotMapped]
    [JsonIgnore]
    public List<INotification> DomainEvents => _domainEvents;

    protected Entity()
    {
        EntityId = Guid.NewGuid();
        _domainEvents = [];
    }

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= [];
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    #region BaseBehaviours

    public override bool Equals(object? obj)
    {
        if (obj is Entity entity)
        {
            if (ReferenceEquals(this, entity))
                return true;

            return EntityId.Equals(entity.EntityId);
        }

        return false;
    }

#pragma warning disable S3875 // "operator==" should not be overloaded on reference types
    public static bool operator ==(Entity objA, Entity objB)
#pragma warning restore S3875 // "operator==" should not be overloaded on reference types
    {
        if (objA is null && objB is null)
            return true;

        if (objA is null || objB is null)
            return false;

        return objA.Equals(objB);
    }

    public static bool operator !=(Entity objA, Entity objB)
    {
        return !(objA == objB);
    }

    public override int GetHashCode()
    {
        if (!_requestedHashCode.HasValue)
            _requestedHashCode = EntityId.GetHashCode() ^ 31;
       
        return _requestedHashCode.Value;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [EntityId={EntityId}]";
    }

    #endregion
}