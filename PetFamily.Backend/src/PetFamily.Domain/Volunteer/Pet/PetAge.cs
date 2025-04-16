

using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.Pet;

public record PetAge
{
    public int Year { get;}
    public int Months { get; }

    private PetAge(int year, int months)
    {
        Year = year;
        Months = months;
    }

    public static Result<PetAge> Create(int year, int months)
    {
        if (year < 0 || year > 9999) 
            return "Year must be between 1 and 9999";
        if (months < 0 || months > 12)
            return "Months must be between 0 and 12";
        
        return new PetAge(year, months);
    }
}