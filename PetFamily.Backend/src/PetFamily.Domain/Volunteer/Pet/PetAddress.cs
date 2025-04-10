
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
    
    public static Result<PetAddress> Create(string city, string street, string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            return "City is not null or empty";
        if (string.IsNullOrWhiteSpace(street))
            return "Street is not null or empty";
        if (string.IsNullOrWhiteSpace(houseNumber))
            return "Housenumber is not null or empty";

        return new PetAddress(city, street, houseNumber);
    }
};
