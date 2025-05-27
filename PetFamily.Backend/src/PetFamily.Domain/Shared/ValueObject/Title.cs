
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObject;

public record Title
{
    public const int MAX_LENGTH = 100;
    private Title(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public Result<Title,Error> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsInvalid("Title");
        
        if (name.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("Title");

        return new Title(name);
    }
}