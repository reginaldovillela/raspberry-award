namespace RaspberryAwardAPI.Domain.Movies;

#pragma warning disable 1591

public class MoviesDomainException : Exception
{
    public Guid EntityId { get; set; }
    public string Title { get; set; }

    public MoviesDomainException(Guid entityId, string title)
    {
        EntityId = entityId;
        Title = title;
    }

    public MoviesDomainException(Guid entityId, string title, string message)
        : base(message)
    {
        EntityId = entityId;
        Title = title;
    }

    public MoviesDomainException(Guid entityId, string title, string message, Exception innerException)
        : base(message, innerException)
    {
        EntityId = entityId;
        Title = title;
    }
}