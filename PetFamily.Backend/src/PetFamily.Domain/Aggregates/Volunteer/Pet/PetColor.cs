using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer.Pet;

public record PetColor
{
    public string Value { get;}
    
    private PetColor(string value)
    {
        Value = value;
    }

    public Result<PetColor,Error> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return Errors.General.ValueIsInvalid("PetColor");

        return new PetColor(color);
    }
}