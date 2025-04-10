namespace PetFamily.Domain.Species;

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; private set; }
    
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid()); 
    public static SpeciesId Empty() => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}