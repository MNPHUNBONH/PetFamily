using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer.Pet;

public record PetAddress
{
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
            return Result.Failure<PetAddress>("City is not null or empty");
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<PetAddress>("Street is not null or empty");
        if (string.IsNullOrWhiteSpace(houseNumber))
            return Result.Failure<PetAddress>("Housenumber is not null or empty");

        return new PetAddress(city, street, houseNumber);
    }
};
