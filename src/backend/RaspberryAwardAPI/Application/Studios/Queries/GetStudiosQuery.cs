using RaspberryAwardAPI.Application.Shared.Dtos;
using RaspberryAwardAPI.Application.Shared.Queries;
using RaspberryAwardAPI.Application.Shared.Results;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public class GetStudiosQuery
    : PagedQuery,
    IRequest<PagedResult<StudioSharedDto>>;