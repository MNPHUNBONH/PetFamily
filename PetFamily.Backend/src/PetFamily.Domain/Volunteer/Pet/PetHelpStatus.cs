using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.Pet;

public record PetHelpStatus
{
    private static readonly string[] _allStatus = ["Нуждается в помощи", "Ищет дом", "Нашел дом"];
    public string Value { get; }

    private PetHelpStatus(string status)
    {
        Value = status;
    }
    public static Result<PetHelpStatus> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Result.Failure<PetHelpStatus>("PetHelpStatus cannot be empty.");

        var status = input.Trim().ToLower();

        var existingStatus = _allStatus.FirstOrDefault(g => g.ToLower() == status);
        if (existingStatus == null)
            return Result.Failure<PetHelpStatus>("PetHelpStatus is not valid.");

        return new PetHelpStatus(input);
    }
}