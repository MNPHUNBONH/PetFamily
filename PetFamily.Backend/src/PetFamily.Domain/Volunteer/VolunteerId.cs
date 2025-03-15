namespace PetFamily.Domain.Volunteer;

public record VolunteerId
{
    private VolunteerId(Guid id)
    {
        Value = id;
    }
    public Guid Value { get; private set; }
    
    public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());

    public static VolunteerId Empty() => new(Guid.Empty);
}