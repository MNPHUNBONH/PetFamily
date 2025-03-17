namespace PetFamily.Domain.Species;

public record BreedId
{
    private BreedId(Guid id)
    {
        Value = id;
    }
    public Guid Value { get; private set; }
    
    public static BreedId NewBreedId() => new(Guid.NewGuid());

    public static BreedId Empty() => new(Guid.Empty);
}