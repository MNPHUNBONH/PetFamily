using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Breed : Shared.Entity<BreedId>
{
    private Breed(BreedId id): base(id) {}
    
    public BreedId Id { get; private set; }
    public Name Name { get; private set; }

    private Breed(BreedId id, Name name) : base(id)
    {
        Id = id;
        Name = name;
    }
    
}