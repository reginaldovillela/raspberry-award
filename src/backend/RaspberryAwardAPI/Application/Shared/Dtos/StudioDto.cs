namespace RaspberryAwardAPI.Application.Shared.Dtos;

#pragma warning disable 1591
public record StudioSharedDto(Guid Id, 
                              string Name);

public record StudioSharedWithMovieDto(Guid Id, 
                                       string Name,
                                       MovieSharedWithProducersDto[] Movies);