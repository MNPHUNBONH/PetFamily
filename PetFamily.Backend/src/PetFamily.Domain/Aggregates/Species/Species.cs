using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObject;

namespace PetFamily.Domain.Aggregates.Species;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    //EF Core
    private Species(SpeciesId id) : base(id) {}
    public Title Title { get; private set; }
    private Species(SpeciesId id, Title title) : base(id)
    {
        Title = title;
    }
    public IReadOnlyList<Breed> Breeds => _breeds;

    public static Result<Species, Error> Create(SpeciesId id, Title title)
    {
        return new Species(id, title);
    }
}