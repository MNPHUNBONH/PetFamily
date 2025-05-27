using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer.Pet;

public record PetAge
{
    public int Year { get;}
    public int Months { get; }

    private PetAge(int year, int months)
    {
        Year = year;
        Months = months;
    }

    public static Result<PetAge,Error> Create(int year, int months)
    {
        if (year < 0 || year > 9999 || months < 0 || months > 12)
            return Errors.General.ValueIsInvalid("PetAge");
        
        return new PetAge(year, months);
    }
}