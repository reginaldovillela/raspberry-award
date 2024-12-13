namespace RaspberryAwardAPI.Application.Shared.Results;

#pragma warning disable 1591
public class PagedResult<T>(IEnumerable<T> itens, 
                            ushort pageNumber, 
                            ushort pageSize, 
                            ushort totalRecords)
{
    public IEnumerable<T> Items { get; } = itens;

    public ushort PageNumber { get; } = pageNumber;

    public ushort PageSize { get; } = pageSize;

    public ushort TotalRecords { get; } = totalRecords;

    public ushort TotalPages => CalculateTotalPages();

    public bool HasNextPage => PageNumber < TotalPages;

    public bool HasPreviousPage => PageNumber > 1;

    private ushort CalculateTotalPages()
    {
        var total = (ushort)(TotalRecords / PageSize);
        
        if (total == 0)
            total = 1;

        return total;
    }
}