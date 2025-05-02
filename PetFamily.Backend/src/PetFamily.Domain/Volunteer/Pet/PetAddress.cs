
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer.Pet;

public record PetAddress
{
    public const int MAX_LENGTH = 100;
    public string City { get;}
    public string Street { get;}
    public string HouseNumber { get; }

    private PetAddress(string city, string street, string houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }
    
    public static Result<PetAddress,Error> Create(string city, string street, string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(city) || 
            string.IsNullOrWhiteSpace(street) ||
            string.IsNullOrWhiteSpace(houseNumber))
            return Errors.General.ValueIsInvalid("PetAddress");
       
        if (city.Length > MAX_LENGTH || street.Length > MAX_LENGTH || houseNumber.Length > MAX_LENGTH)
            return Errors.General.ValueIsRequired("PetAddress");

        return new PetAddress(city, street, houseNumber);
    }
};
