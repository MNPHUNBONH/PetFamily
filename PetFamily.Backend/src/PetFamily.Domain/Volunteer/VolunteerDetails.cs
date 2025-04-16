using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerDetails
{
    private readonly List<VolunteerSocialNetwork> socialNetworks;
    private readonly List<PaymentDetails> paymentsDetails;
    
    public IReadOnlyList<VolunteerSocialNetwork> SocialNetworks => socialNetworks;
    public IReadOnlyList<PaymentDetails> PaymentDetails => paymentsDetails;
    
    private VolunteerDetails(){}
    private VolunteerDetails(List<VolunteerSocialNetwork> socialnetworks,
        List<PaymentDetails> paymentsdetails) 
    {
        socialNetworks = socialnetworks.ToList();
        paymentsDetails = paymentsdetails.ToList();
    }

    public static Result<VolunteerDetails> Create(List<VolunteerSocialNetwork> socialnetworks,
        List<PaymentDetails> payments) =>
        new VolunteerDetails(socialnetworks, payments);
}