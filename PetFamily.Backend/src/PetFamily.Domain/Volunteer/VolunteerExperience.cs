
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerExperience
{
    public int Value { get;}
    private VolunteerExperience(int value)
    {
       Value = value;
    }

    public static Result<VolunteerExperience> Create(int experiens)
    {
        if (experiens < 0 || experiens > 100) 
            return "Experiens must be between 0 and 100";
        
        return new VolunteerExperience(experiens);
    }
}