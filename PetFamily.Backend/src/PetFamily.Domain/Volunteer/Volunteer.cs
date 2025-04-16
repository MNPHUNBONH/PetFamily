using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public class Volunteer : Entity<VolunteerId>
{
    private readonly List<Pet.Pet> _pets = [];
    private readonly List<VolunteerSocialNetwork> _socialNetworks = [];
    private readonly List<PaymentDetails> _paymentDetails = [];

    //EF Core
    private Volunteer(VolunteerId id) : base(id)
    {
    }
    public VolunteerFullName FullName { get; private set; }
    public VolunteerEmail Email { get; private set; }
    public Description Description { get; private set; }
    public VolunteerExperience Experience { get; private set; }
    public PhoneNumber Phone { get; private set; } = default!;
    public VolunteerDetails VolunteerDetails;
    public IReadOnlyList<Pet.Pet> Pets => _pets;


    private Volunteer(VolunteerId volunteerId,
        VolunteerFullName name,
        VolunteerEmail email,
        Description description,
        PhoneNumber phoneNumber,
        VolunteerExperience experience) : base(volunteerId)
    {
        FullName = name;
        Email = email;
        Description = description;
        Phone = phoneNumber;
        Experience = experience;
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
}