namespace RaspberryAwardAPI.Application.Shared.Queries;

#pragma warning disable 1591
public abstract class PagedQuery
{
    [DefaultValue(1)]
    [FromQuery(Name = "_pageNumber")]
    [Range(typeof(ushort), "1", "9999")]
    public ushort PageNumber { get; init; } = 1;

    [DefaultValue(10)]
    [FromQuery(Name = "_pageSize")]
    [MinLength(1)]
    [MaxLength(100)]
    [Range(1, 100)]
    public ushort PageSize { get; init; } = 10;
}