using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer;

public record VolunteerExperience
{
    public int Value { get;}
    private VolunteerExperience(int value)
    {
       Value = value;
    }

    public static Result<VolunteerExperience,Error> Create(int experiens)
    {
        if (experiens < 0 || experiens > 100) 
            return Errors.General.ValueIsInvalid("VolunteerExperience");
        
        return new VolunteerExperience(experiens);
    }
}