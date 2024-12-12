using RaspberryAwardAPI.Application.Movies.Dtos;

namespace RaspberryAwardAPI.Application.Movies.Queries;

#pragma warning disable 1591
public record GetMoviesQuery : IRequest<MovieDto[]>;