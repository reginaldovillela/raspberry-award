namespace RaspberryAwardAPI.Application.Shared.Dtos;

#pragma warning disable 1591
public record ProducerSharedDto(Guid Id, 
                                string Name);

public record ProducerSharedWithMovieDto(Guid Id, 
                                         string Name,
                                         MovieSharedWithStudiosDto[] Movies);
