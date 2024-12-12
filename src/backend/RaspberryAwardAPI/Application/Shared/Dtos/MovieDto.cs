namespace RaspberryAwardAPI.Application.Shared.Dtos;

#pragma warning disable 1591
public record MovieSharedDto(Guid Id, 
                             string Title, 
                             ushort Year, 
                             bool Winner);