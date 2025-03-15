using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Description
{
    private Description(string description)
    {
        Value = description;
    }
    public string Value { get; }

    public Result<Description> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Description>("Description is not null or empty");

        return new Description(description);
    }
}