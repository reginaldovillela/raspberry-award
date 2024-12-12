namespace RaspberryAwardAPI.Domain.SeedWork;

#pragma warning disable 1591
public class PagedList<T>(IEnumerable<T> itens, 
                          ushort pageNumber, 
                          ushort pageSize, 
                          ushort totalRecords)
{
    public IEnumerable<T> Items { get; } = itens;

    public ushort PageNumber { get; } = pageNumber;

    public ushort PageSize { get; } = pageSize;

    public ushort TotalRecords { get; } = totalRecords;

    public ushort TotalPages => (ushort)Math.Abs(TotalRecords / PageSize);

    public bool HasNextPage => PageNumber * PageSize < TotalRecords;

    public bool HasPreviousPage => PageNumber > 1;
}