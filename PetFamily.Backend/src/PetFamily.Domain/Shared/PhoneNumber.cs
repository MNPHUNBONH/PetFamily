using System.Text.RegularExpressions;

namespace PetFamily.Domain.Shared;

public record PhoneNumber
{
    public const int MAX_LENGTH = 15;
    private const string _phoneRegex = @"^\+?\d{1,3}[-\s]?\(?\d{1,4}\)?[-\s]?\d{1,4}[-\s]?\d{1,9}$";

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return "Phone number is not null or empty";

        if (Regex.IsMatch(number, _phoneRegex) == false)
            return "Phone number is not in valid format";

        return new PhoneNumber(number);
    }
}