using PetFamily.Application.Volunteers.CreateVolunteer;

namespace PetFamily.Application.Volunteers.Commands;

public record CreateVolunteerCommand(
    VolunteerFullNameDto VolunteerFullName,
    string Email,
    string Description,
    int Experience,
    string Phone,
    IEnumerable<VolunteerSocialNetworkDto> SocialNetwork,
    IEnumerable<VolunteerPaymentDetailsDto> PaymentDetails);