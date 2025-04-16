

using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.Pet;

public record PetGender
{
    public static readonly PetGender Male = new (nameof(Male));
    public static readonly PetGender Female = new (nameof(Female));
    
    private static readonly PetGender[] _all = [Male, Female];
    public string Value { get;}
    private PetGender(string value)
    {
        Value = value;
    }

    public static Result<PetGender> Create(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
            return "Gender cannot be empty.";

        var gender = input.Trim().ToUpper();

        if (_all.Any(g => g.Value.ToLower() == gender) == false)
            return "Gender is not valid.";

        return new PetGender(input);
    }
}