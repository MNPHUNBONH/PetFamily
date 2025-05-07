namespace PetFamily.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    VolunteerFullNameDto VolunteerFullName,
    string Email,
    string Description,
    int Experience,
    string Phone,
    IEnumerable<VolunteerSocialNetworkDto> SocialNetwork,
    IEnumerable<VolunteerPaymentDetailsDto> PaymentDetails);