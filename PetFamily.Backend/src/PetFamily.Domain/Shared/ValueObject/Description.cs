using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObject;

public record Description
{
    public const int MAX_LENGTH = 2000;
    public string Value { get; }
    private Description(string value)
    {
        Value = value;
    }
    public static Result<Description,Error> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("Description");
        if (description.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("Description");

        return new Description(description);
    }
}