using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    
    private Species(SpeciesId id) : base(id) {}
    
    public SpeciesId Id { get; private set; }
    public Name Name { get; private set; }
    private Species(SpeciesId id, Name name) : base(id)
    {
        Id = id;
        Name = name;
    }
    
    public IReadOnlyList<Breed> Breeds => _breeds; 
}