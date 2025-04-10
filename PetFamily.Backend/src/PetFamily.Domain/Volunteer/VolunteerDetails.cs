using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerDetails()
{
    public List<VolunteerSocialNetwork> SocialNetworks { get;}
    public List<PaymentDetails> PaymentDetails { get;}
};