 using PetFamily.Application.Volunteers.CreateVolunteer;
 using PetFamily.Application.Volunteers.DTOs;

 namespace PetFamily.Application.Volunteers.Commands;

public record CreateVolunteerCommand(
    VolunteerFullNameDto VolunteerFullName,
    string Email,
    string Description,
    int Experience,
    string Phone,
    IEnumerable<VolunteerSocialNetworkDto> SocialNetworks,
    IEnumerable<VolunteerPaymentDetailsDto> PaymentDetails);