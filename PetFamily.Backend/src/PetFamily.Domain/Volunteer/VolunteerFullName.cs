

using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerFullName
{
    public const int MAX_LENGTH = 100;
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
            return "FirstName is not null or empty";
        
        if (string.IsNullOrWhiteSpace(lastName)) 
            return "LastName is not null or empty";
        
        if (string.IsNullOrWhiteSpace(middleName))
            return "MiddleName is not null or empty";
        
        return new VolunteerFullName(firstName, lastName, middleName);
    }
    
}