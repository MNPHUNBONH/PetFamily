using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Name
{
    private Name(string name)
    {
        Value = name;
    }

    public string Value { get; }

    public Result<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Name>("Name is not null or empty");

        return new Name(name);
    }
}