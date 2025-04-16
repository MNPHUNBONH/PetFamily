
namespace PetFamily.Domain.Shared;

public record Title
{
    public const int MAX_LENGTH = 100;
    private Title(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public Result<Title> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Name is not null or empty";

        return new Title(name);
    }
}