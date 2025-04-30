using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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

    public static Result<PetSize, Error> Create(float height, float weight)
    {
        if (height < 0 || weight < 0)
            return Errors.General.ValueIsInvalid("PetSize");
        
        return new PetSize(height, weight);
    }
}