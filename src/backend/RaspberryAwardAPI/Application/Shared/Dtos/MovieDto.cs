namespace RaspberryAwardAPI.Application.Shared.Dtos;

#pragma warning disable 1591
public record MovieSharedDto(Guid Id, 
                             string Title, 
                             ushort Year, 
                             bool Winner);

public record MovieSharedWithStudiosDto(Guid Id, 
                                        string Title, 
                                        ushort Year, 
                                        bool Winner,
                                        IEnumerable<StudioSharedDto> Studios);

public record MovieSharedWithProducersDto(Guid Id, 
                                          string Title, 
                                          ushort Year, 
                                          bool Winner,
                                          IEnumerable<ProducerSharedDto> Producers);

public record MovieSharedWithStudiosAndProducersDto(Guid Id, 
                                                    string Title, 
                                                    ushort Year, 
                                                    bool Winner,
                                                    IEnumerable<StudioSharedDto> Studios,
                                                    IEnumerable<ProducerSharedDto> Producers);