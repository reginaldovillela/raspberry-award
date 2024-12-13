namespace RaspberryAwardAPI.Application.Producers.Dtos;

#pragma warning disable 1591
public record ProducerWinnner(string Producer, 
                              ushort Interval, 
                              ushort PreviousYearWin, 
                              ushort FollingYearWin);
