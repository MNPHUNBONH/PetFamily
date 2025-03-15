namespace PetFamily.Domain.Volunteer.Pet;

public record PetId
{
    private PetId(Guid id)
    {
        Value = id;
    }
    public Guid Value { get; private set; }
    
    public static PetId NewPetId() => new(Guid.NewGuid());

    public static PetId Empty() => new(Guid.Empty);
}