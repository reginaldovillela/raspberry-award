using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public class GetStudiosQueryHandler(ILogger<GetStudiosQueryHandler> logger,
                                    IStudiosRepository repository) : IRequestHandler<GetStudiosQuery, IEnumerable<StudioSharedDto>>
{
    public async Task<IEnumerable<StudioSharedDto>> Handle(GetStudiosQuery request, CancellationToken cancellationToken)
    {
        var studios = await repository.GetAllAsync(cancellationToken);
        
        logger.LogInformation("Consulta concluída. Total de {@count} encontrados", studios.Count);
        
        return studios.Select(s => new StudioSharedDto(s.EntityId, s.Name));
    }
}