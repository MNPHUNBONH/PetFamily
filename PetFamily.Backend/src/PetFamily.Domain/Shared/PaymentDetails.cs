
namespace PetFamily.Domain.Shared;

public record PaymentDetails
{
    public string Name { get;}
    public string Description { get;} 
    
    private PaymentDetails(string name, string description)
    {
        Name = name;
        Description = description;
    }
    

    public Result<PaymentDetails> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Name is not null or empty";
        if (string.IsNullOrWhiteSpace(description))
            return "Description is not null or empty";

        return new PaymentDetails(name, description);
    }
        
}