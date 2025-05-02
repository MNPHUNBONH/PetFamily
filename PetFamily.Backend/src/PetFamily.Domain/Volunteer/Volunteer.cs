using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet.Pet> _pets = [];
    private readonly List<VolunteerSocialNetwork> _socialNetworks = [];
    private readonly List<VolunteerPaymentDetails> _paymentDetails = [];

    //EF Core
    private Volunteer(VolunteerId id) : base(id)
    {
    }
    public VolunteerFullName FullName { get; private set; }
    public VolunteerEmail Email { get; private set; }
    public Description Description { get; private set; }
    public VolunteerExperience Experience { get; private set; }
    public PhoneNumber Phone { get; private set; } = default!;
    
    public TransferSocialNetworkList TransferSocialNetworkList { get; private set; }
    public TransferPaymentDetailsList TransferPaymentDetailsList { get; private set; }
    public IReadOnlyList<Pet.Pet> Pets => _pets;


    private Volunteer(VolunteerId volunteerId,
        VolunteerFullName name,
        VolunteerEmail email,
        VolunteerExperience experience,
        Description description,
        PhoneNumber phoneNumber,
        TransferPaymentDetailsList transferPaymentDetailsList,
        TransferSocialNetworkList transferSocialNetworkList) : base(volunteerId)
    {
        FullName = name;
        Email = email;
        Description = description;
        Phone = phoneNumber;
        Experience = experience;
        TransferPaymentDetailsList = transferPaymentDetailsList;
        TransferSocialNetworkList = transferSocialNetworkList;
    }

    public IReadOnlyList<Pet.Pet> GetPetsNeedHome()
    {
        var needHome = _pets.Where(p => p.HelpStatus.Value == "Ищет дом").ToList().AsReadOnly();;
        return needHome;
    }
    public IReadOnlyList<Pet.Pet> GetPetsFoundHome()
    {
        var foundHome = _pets.Where(p => p.HelpStatus.Value == "Нашел дом").ToList().AsReadOnly();
        return foundHome;
    }
    public IReadOnlyList<Pet.Pet> GetPetsNeedHelp()
    {
        var foundHome = _pets.Where(p => p.HelpStatus.Value == "Нуждается в помощи").ToList().AsReadOnly();
        return foundHome;
    }

    public static Result<Volunteer,Error> Create(VolunteerId volunteerId,VolunteerFullName fullName, VolunteerEmail email, Description description,
        VolunteerExperience experience, PhoneNumber phoneNumber, TransferPaymentDetailsList transferPaymentDetailsList = null, TransferSocialNetworkList transferSocialNetworkList = null)
    {
        if (volunteerId == null || fullName == null || email == null || description == null || phoneNumber == null)
            return Errors.General.ValueIsInvalid("Volunteer");
        
        return new Volunteer(volunteerId,fullName, email, experience, description, phoneNumber, transferPaymentDetailsList, transferSocialNetworkList);
    }
}