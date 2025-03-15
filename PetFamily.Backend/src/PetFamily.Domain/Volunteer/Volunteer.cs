using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public class Volunteer : Shared.Entity<VolunteerId>
{ 
    private readonly List<Pet.Pet> _pets = [];
    private readonly List<VolunteerSocialNetwork> _socialNetworks = [];
    private readonly List<PaymentDetails> _paymentDetails = [];
    
    private Volunteer(VolunteerId id) : base(id)
    {
    }
    public VolunteerId VolunteerId { get; private set; }
    public VolunteerFullName FullName { get; private set; }
    public VolunteerEmail Email { get; private set; }  
    public Description GeneralDescription { get; private set; }
    public int Experience { get; private set; } = default!;
    public PhoneNumber Phone { get; private set; } = default!;
    
    public IReadOnlyList<PaymentDetails> PaymentDetails => _paymentDetails;
    public IReadOnlyList<VolunteerSocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<Pet.Pet> Pets => _pets;


    private Volunteer(VolunteerId id, 
        VolunteerFullName name,
        VolunteerEmail email, 
        Description description, 
        PhoneNumber phoneNumber, 
        int experience = 0) : base(id)
    {
        VolunteerId = id;
        FullName = name;
        Email = email;
        GeneralDescription = description;
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