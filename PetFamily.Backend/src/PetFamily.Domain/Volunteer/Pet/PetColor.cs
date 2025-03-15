namespace PetFamily.Domain.Volunteer.Pet;

public record PetColor
{
    public string Color { get;}
    
    public PetColor(string color)
    {
        Color = color;
    }
}