namespace RaspberryAwardAPI.Application.Producers.Dtos;

#pragma warning disable 1591
public record MovieDto(Guid Id, 
                       string Title, 
                       ushort Year, 
                       bool Winner, 
                       List<StudioDto> Studios, 
                       List<ProducerDto> Producers);