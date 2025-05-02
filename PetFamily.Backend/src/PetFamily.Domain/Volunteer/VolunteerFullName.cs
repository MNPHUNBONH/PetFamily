

using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerFullName
{
    public const int MAX_LENGTH = 100;
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName() => $"{FirstName} {LastName}";

    private VolunteerFullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Result<VolunteerFullName,Error> Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            return Errors.General.ValueIsInvalid("VolunteerFullName");
        
        if (firstName.Length > MAX_LENGTH || lastName.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("VolunteerFullName");
        
        return new VolunteerFullName(firstName, lastName);
    }
    
}