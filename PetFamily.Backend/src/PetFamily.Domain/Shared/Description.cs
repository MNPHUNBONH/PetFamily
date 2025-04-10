

namespace PetFamily.Domain.Shared;

public record Description
{
    public const int MAX_LENGTH = 2000;
    public string Value { get; }
    private Description(string value)
    {
        Value = value;
    }
    public Result<Description> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Description is not null or empty";

        return new Description(value);
    }
}