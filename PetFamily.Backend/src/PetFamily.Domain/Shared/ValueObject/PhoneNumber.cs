using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObject;

public record PhoneNumber
{
    public const int MAX_LENGTH = 15;
    private const string _phoneRegex = @"^\+?\d{1,3}[-\s]?\(?\d{1,4}\)?[-\s]?\d{1,4}[-\s]?\d{1,9}$";

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsRequired("Phone");

        var number = input.Trim();

        if (number.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("Phone");

        if (Regex.IsMatch(number, _phoneRegex) == false)
            return Errors.General.ValueIsInvalid("Phone");

        return new PhoneNumber(number);
    }
}