
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer;

public record VolunteerPaymentDetails
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_DESCRIPTION_LENGTH = 2000;
    
    public string Name { get;}
    public string Description { get;} 
    
    private VolunteerPaymentDetails(string name, string description)
    {
        Name = name;
        Description = description;
    }
    

    public static Result<VolunteerPaymentDetails,Error> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsInvalid("Payment Details");
        
        if (name.Length > MAX_NAME_LENGTH || description.Length > MAX_DESCRIPTION_LENGTH)
            return Errors.General.ValueIsRequired("Payment Details");

        return new VolunteerPaymentDetails(name, description);
    }
        
}