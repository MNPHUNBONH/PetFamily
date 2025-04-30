using CSharpFunctionalExtensions;
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

    public async Task<Result<Guid, Error>> Handler(CreateVolunteerRequest createVolunteerRequest,
        CancellationToken cancellationToken = default)
    {
        //Валидация
        // получить модуль с названием из requast и если он существует то вернуть ошибку

        var volunteerId = VolunteerId.NewVolunteerId();

        var volunteerFullName =
            VolunteerFullName.Create(createVolunteerRequest.FirstName, createVolunteerRequest.LastName);
        if (volunteerFullName.IsFailure)
            return Errors.General.ValueIsInvalid();


        var volunteerDescription = Description.Create(createVolunteerRequest.Description);
        if (volunteerDescription.IsFailure)
            return Errors.General.ValueIsInvalid();

        var volunteerEmail = VolunteerEmail.Create(createVolunteerRequest.Email);
        if (volunteerEmail.IsFailure)
            return Errors.General.ValueIsInvalid();

        var moduleExist = _volunteersRepository.GetByEmail(volunteerEmail.Value);
        
        if (moduleExist.Result.IsSuccess)
            return Errors.Volunteer.AlreadyExist();

        var volunteerExperience = VolunteerExperience.Create(createVolunteerRequest.Experience);
        if (volunteerExperience.IsFailure)
            return Errors.General.ValueIsInvalid();

        var volunteerPhone = PhoneNumber.Create(createVolunteerRequest.Phone);
        if (volunteerPhone.IsFailure)
            return Errors.General.ValueIsInvalid();
        
        //тест данные для соц сетей 
        var socNetwork1 = VolunteerSocialNetwork.Create("Vkontakte", "vkontakte@gmail.com");
        var socNetwork2 = VolunteerSocialNetwork.Create("Twitter", "twitte/12231.com");
        var socTransfer = TransferSocialNetworkList.Create(new List<VolunteerSocialNetwork>{socNetwork1.Value,socNetwork2.Value});
        
        //тест Данные для Реквизитов оплаты
        
        var paymentDetails1 = VolunteerPaymentDetails.Create("PayPal","Number:123456");
        var paymentDetails2 = VolunteerPaymentDetails.Create("BelBANK","Number:6623123");
        var payTransfer = TransferPaymentDetailsList.Create(new List<VolunteerPaymentDetails>{paymentDetails1.Value,paymentDetails2.Value});
        //Создание домен модели
        var volunteerResult = Volunteer.Create(volunteerId, volunteerFullName.Value,
            volunteerEmail.Value, volunteerDescription.Value, volunteerExperience.Value, volunteerPhone.Value,payTransfer.Value,socTransfer.Value);

        if (volunteerResult.IsFailure)
            return Errors.General.ValueIsInvalid();

        //Сохранине в бд
        await _volunteersRepository.Add(volunteerResult.Value, cancellationToken);

        return volunteerResult.Value.Id.Value;
    }
}