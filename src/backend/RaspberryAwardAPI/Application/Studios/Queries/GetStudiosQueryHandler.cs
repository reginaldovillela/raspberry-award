using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public class GetStudiosQueryHandler(ILogger<GetStudiosQueryHandler> logger,
                                    IStudiosRepository repository) : IRequestHandler<GetStudiosQuery, PagedResult<StudioSharedDto>>
{
    public async Task<PagedResult<StudioSharedDto>> Handle(GetStudiosQuery request, CancellationToken cancellationToken)
    {
        var studios = await repository.GetAllPagedAsync(request.PageNumber, request.PageSize, cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", studios.Items.Count());

        return new PagedResult<StudioSharedDto>(
            studios.Items.Select(s => new StudioSharedDto(s.EntityId, s.Name)),
            studios.PageNumber,
            studios.PageSize,
            studios.TotalRecords
        );
    }
}