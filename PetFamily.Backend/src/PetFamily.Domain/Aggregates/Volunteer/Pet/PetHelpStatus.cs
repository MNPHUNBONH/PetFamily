using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer.Pet;

public record PetHelpStatus
{
    private static readonly string[] _allStatus = ["Нуждается в помощи", "Ищет дом", "Нашел дом"];
    public string Value { get; }

    private PetHelpStatus(string value)
    {
        Value = value;
    }
    public static Result<PetHelpStatus, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsInvalid("PetHelpStatus");

        var status = input.Trim().ToLower();

        var existingStatus = _allStatus.FirstOrDefault(g => g.ToLower() == status);
        if (existingStatus == null)
            return Errors.General.ValueIsInvalid("PetHelpStatus");

        return new PetHelpStatus(input);
    }
}