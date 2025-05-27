using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer.Pet;

public record PetGender
{
    public static readonly PetGender Male = new(nameof(Male));
    public static readonly PetGender Female = new(nameof(Female));

    private static readonly PetGender[] _all = [Male, Female];
    public string Value { get; }

    private PetGender(string value)
    {
        Value = value;
    }

    public static Result<PetGender,Error> Create(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsInvalid("PetGender");

        var gender = input.Trim().ToUpper();

        if (_all.Any(g => g.Value.ToLower() == gender) == false)
            return Errors.General.ValueIsInvalid("PetGender");

        return new PetGender(input);
    }
}