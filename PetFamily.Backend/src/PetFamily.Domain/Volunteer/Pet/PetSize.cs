namespace PetFamily.Domain.Volunteer.Pet;

public record PetSize
{
    public float Weight { get;}
    public float Height { get;}

    public PetSize(float height, float weight)
    {
        Height = height;    
        Weight = weight;
    }
}