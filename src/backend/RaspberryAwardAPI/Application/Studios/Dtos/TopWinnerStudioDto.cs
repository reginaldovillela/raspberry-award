using RaspberryAwardAPI.Application.Shared.Dtos;

namespace RaspberryAwardAPI.Application.Studios.Dtos;

#pragma warning disable 1591
public record TopWinnerStudioDto(Guid Id, 
                                 string Name, 
                                 ushort WinCount, 
                                 [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
                                 IEnumerable<MovieSharedDto>? Movies);