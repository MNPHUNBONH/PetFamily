using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer;

public record VolunteerEmail
{
    public string Email { get; }

    private VolunteerEmail(string email)
    {
        Email = email;
    }
    
    public static Result<VolunteerEmail> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) 
            return Result.Failure<VolunteerEmail>("Email is not null or empty");
        
        return new VolunteerEmail(email);
    }
    
};