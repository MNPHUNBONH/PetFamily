using CSharpFunctionalExtensions;
using PetFamily.Application.Volunteers.Commands;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Guid, Error>> Handler(CreateVolunteerCommand command,
        CancellationToken cancellationToken = default)
    {
        var volunteerId = VolunteerId.NewVolunteerId();

        var volunteerFullName =
            VolunteerFullName.Create(command.VolunteerFullName.FirstName,
                command.VolunteerFullName.LastName);
        if (volunteerFullName.IsFailure)
            return volunteerFullName.Error;


        var volunteerDescription = Description.Create(command.Description);
        if (volunteerDescription.IsFailure)
            return volunteerDescription.Error;

        var volunteerEmail = VolunteerEmail.Create(command.Email);
        if (volunteerEmail.IsFailure)
            return volunteerEmail.Error;

        var moduleExist = _volunteersRepository.GetByEmail(volunteerEmail.Value);

        if (moduleExist.Result.IsSuccess)
            return Errors.Volunteer.AlreadyExist();

        var volunteerExperience = VolunteerExperience.Create(command.Experience);
        if (volunteerExperience.IsFailure)
            return volunteerExperience.Error;

        var volunteerPhone = PhoneNumber.Create(command.Phone);
        if (volunteerPhone.IsFailure)
            return volunteerPhone.Error;

        var socialNetworkList = new List<VolunteerSocialNetwork>();

        foreach (var volunteerSocialNetwork in command.SocialNetwork)
        {
            var socialNetwork =
                VolunteerSocialNetwork.Create(volunteerSocialNetwork.Name, volunteerSocialNetwork.Link);
            if (socialNetwork.IsFailure)
                return socialNetwork.Error;
            socialNetworkList.Add(socialNetwork.Value);
        }

        var socTransfer = TransferSocialNetworkList.Create(socialNetworkList);

        var paymenDetailsList = new List<VolunteerPaymentDetails>();
        foreach (var volunteerPaymentDetails in command.PaymentDetails)
        {
            var paymentDetails =
                VolunteerPaymentDetails.Create(volunteerPaymentDetails.Name,
                    volunteerPaymentDetails.Description);
            if (paymentDetails.IsFailure)
                return paymentDetails.Error;
            paymenDetailsList.Add(paymentDetails.Value);
        }

        var payTransfer = TransferPaymentDetailsList.Create(paymenDetailsList);

        var volunteerResult = Volunteer.Create(
            volunteerId,
            volunteerFullName.Value,
            volunteerEmail.Value,
            volunteerDescription.Value,
            volunteerExperience.Value, 
            volunteerPhone.Value,
            payTransfer.Value, 
            socTransfer.Value);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        //Сохранине в бд
        await _volunteersRepository.Add(volunteerResult.Value, cancellationToken);

        return volunteerResult.Value.Id.Value;
    }
}