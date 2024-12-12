using RaspberryAwardAPI.Application.Shared.Dtos;

namespace RaspberryAwardAPI.Application.Studios.Queries;

#pragma warning disable 1591
public record GetStudiosQuery : IRequest<IEnumerable<StudioSharedDto>>;