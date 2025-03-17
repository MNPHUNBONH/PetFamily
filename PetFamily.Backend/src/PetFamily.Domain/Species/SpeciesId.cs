namespace PetFamily.Domain.Species;

public record SpeciesId
{
    private SpeciesId(Guid id)
    {
        Value = id;
    }
    public Guid Value { get; private set; }
    
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());

    public static SpeciesId Empty() => new(Guid.Empty);
}