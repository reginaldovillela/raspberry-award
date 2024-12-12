using System.ComponentModel.DataAnnotations.Schema;
using RaspberryAwardAPI.Domain.Producers;
using RaspberryAwardAPI.Domain.SeedWork;
using RaspberryAwardAPI.Domain.SeedWork.Interfaces;
using RaspberryAwardAPI.Domain.Studios;

namespace RaspberryAwardAPI.Domain.Movies;

#pragma warning disable 1591

[Table("movies")]
public class Movie
    : Entity, IAggregateRoot
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Title { get; private set; }
    
    [Required]
    [Column(TypeName = "smallint")]
    public ushort Year { get; private set; }
    
    [Required]
    public bool Winner { get; private set; }
    
    public List<Studio> Studios { get; private set; }

    public List<Producer> Producers { get; private set; }
    
    #region "ef requirements and relations"

#pragma warning disable CS8618
    protected Movie() { }
#pragma warning restore CS8618

    #endregion

    public Movie(string title, ushort year, bool winner)
    {
        Title = title;
        SetYear(year);
        Winner = winner;
        Studios = [];
        Producers = [];
    }
    
    public void SetYear(ushort year)
    {
        if (year > DateTime.UtcNow.Year + 1)
            throw new MoviesDomainException(EntityId, Title, "Esse filme vem do futuro?!");

        Year = year;
    }

    public void AddProducer(Producer producer)
    {
        Producers.Add(producer);
    }

    public void AddProducers(params Producer[] producers)
    {
        Producers.AddRange(producers);
    }

    public void AddStudio(Studio studio)
    {
        Studios.Add(studio);
    }

    public void AddStudios(params Studio[] studios)
    {
        Studios.AddRange(studios);
    }
}