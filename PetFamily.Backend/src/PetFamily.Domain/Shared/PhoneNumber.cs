using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record PhoneNumber
{
    private PhoneNumber( string number)
    {
        Value = number;
    }
    public string Value { get; }
    
    public Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return Result.Failure<PhoneNumber>("Phone number is not null or empty");

        return new PhoneNumber(number);
    }
}