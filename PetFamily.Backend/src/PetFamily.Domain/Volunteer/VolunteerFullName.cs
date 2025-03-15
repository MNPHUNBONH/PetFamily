using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer;

public record VolunteerFullName
{
    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }
    
    public string FullName() => $"{FirstName} {LastName}  {MiddleName}";

    private VolunteerFullName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public static Result<VolunteerFullName> Create(string firstName, string lastName, string middleName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) 
            return Result.Failure<VolunteerFullName>("FirstName is not null or empty");
        
        if (string.IsNullOrWhiteSpace(lastName)) 
            return Result.Failure<VolunteerFullName>("LastName is not null or empty");
        
        if (string.IsNullOrWhiteSpace(middleName))
            return Result.Failure<VolunteerFullName>("MiddleName is not null or empty");
        
        return new VolunteerFullName(firstName, lastName, middleName);
    }
    
}