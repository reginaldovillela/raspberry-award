using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Results;
using RaspberryAwardAPI.Domain.Producers;

namespace RaspberryAwardAPI.Application.Producers.Queries;

#pragma warning disable 1591
public class GetProducersQueryHandler(
    ILogger<GetProducersQueryHandler> logger,
    IProducersRepository repository) : IRequestHandler<GetProducersQuery, PagedResult<ProducerSharedDto>>
{
    public async Task<PagedResult<ProducerSharedDto>> Handle(GetProducersQuery request, CancellationToken cancellationToken)
    {
        var producers = await repository.GetAllPagedAsync(request.PageNumber, request.PageSize, cancellationToken);

        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", producers.Items.Count());
        
        return new PagedResult<ProducerSharedDto>(
            producers.Items.Select(p => new ProducerSharedDto(p.EntityId, p.Name)),
            producers.PageNumber,
            producers.PageSize,
            producers.TotalRecords
        );
    }
}