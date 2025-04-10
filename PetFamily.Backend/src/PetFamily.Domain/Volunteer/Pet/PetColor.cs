namespace PetFamily.Domain.Volunteer.Pet;

public record PetColor
{
    public string Value { get;}
    
    public PetColor(string value)
    {
        Value = value;
    }
}