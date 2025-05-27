using CSharpFunctionalExtensions;
using FluentValidation;
using PetFamily.Application.Extensions;
using PetFamily.Application.Volunteers.Commands;
using PetFamily.Domain.Aggregates.Volunteer;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObject;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly IValidator<CreateVolunteerCommand> _validator;

    public CreateVolunteerHandler(
        IVolunteersRepository volunteersRepository,
        IValidator<CreateVolunteerCommand> validator)
    {
        _volunteersRepository = volunteersRepository;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handler(CreateVolunteerCommand command,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
           return validationResult.ToErrorList();
        }

        var volunteerId = VolunteerId.NewVolunteerId();

        var volunteerFullName = VolunteerFullName.Create(command.VolunteerFullName.FirstName,
            command.VolunteerFullName.LastName).Value;

        var volunteerDescription = Description.Create(command.Description).Value;
        var volunteerEmail = VolunteerEmail.Create(command.Email).Value;

        var moduleExist = _volunteersRepository.GetByEmail(volunteerEmail);

        if (moduleExist.Result.IsSuccess)
            return Errors.Volunteer.AlreadyExist().ToErrorList();

        var volunteerExperience = VolunteerExperience.Create(command.Experience).Value;
        var volunteerPhone = PhoneNumber.Create(command.Phone).Value;

        var socialNetworkList = command.SocialNetworks
            .Select(sn => VolunteerSocialNetwork.Create(sn.Name, sn.Link).Value)
            .ToList();
        var socTransfer = TransferSocialNetworkList.Create(socialNetworkList);

        var paymenDetailsList = command.PaymentDetails
            .Select(c => VolunteerPaymentDetails.Create(c.Name, c.Description).Value)
            .ToList();
        var payTransfer = TransferPaymentDetailsList.Create(paymenDetailsList);

        var volunteerResult = Volunteer.Create(
            volunteerId,
            volunteerFullName,
            volunteerEmail,
            volunteerDescription,
            volunteerExperience,
            volunteerPhone,
            payTransfer.Value,
            socTransfer.Value);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error.ToErrorList();

        await _volunteersRepository.Add(volunteerResult.Value, cancellationToken);

        return volunteerResult.Value.Id.Value;
    }
}