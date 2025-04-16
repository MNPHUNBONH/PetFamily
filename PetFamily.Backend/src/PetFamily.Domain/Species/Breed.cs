using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Breed : Shared.Entity<BreedId>
{
    public Breed(BreedId id): base(id) {}
    public Title Title { get; private set; }

    public Breed(BreedId id, Title title) : base(id)
    {
        Title = title;
    }
    
}