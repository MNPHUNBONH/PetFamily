
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerEmail
{
    public const int MAX_LENGTH = 100;
    public string Value { get; }

    private VolunteerEmail(string value)
    {
        Value = value;
    }
    
    public static Result<VolunteerEmail> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) 
            return "Email is not null or empty";
        
        return new VolunteerEmail(email);
    }
    
};