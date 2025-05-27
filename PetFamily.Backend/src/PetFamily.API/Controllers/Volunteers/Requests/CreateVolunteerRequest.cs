using PetFamily.Application.Volunteers.Commands;
using PetFamily.Application.Volunteers.DTOs;

namespace PetFamily.API.Controllers.Volunteers.Requests;

public record CreateVolunteerRequest(
    VolunteerFullNameDto VolunteerFullName,
    string Email,
    string Description,
    int Experience,
    string Phone,
    IEnumerable<VolunteerSocialNetworkDto> SocialNetwork,
    IEnumerable<VolunteerPaymentDetailsDto> PaymentDetails)
{
    public CreateVolunteerCommand ToCommand() =>
    new CreateVolunteerCommand(VolunteerFullName, Email, Description, Experience, Phone, SocialNetwork, PaymentDetails);
};