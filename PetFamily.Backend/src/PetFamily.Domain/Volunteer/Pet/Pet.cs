using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteer.Pet;
public class Pet : Shared.Entity<PetId>
{
    private Pet(PetId id) : base(id)
     {
     } 
    public PetId Id { get; private set; } 
    public Name Name { get; private set; }
    public SpeciesId SpeciesId { get; private set; }
    public Description Description { get; private set; }
    public PetGender PetGender { get; private set; }
    public BreedId BreedId { get; private set; }
    public PetAddress Address { get; private set; }
    public PetColor Color { get; private set; }
    public Description HealthInformation { get; private set; }
    public PetSize PetSize { get; private set; }
    public PhoneNumber PhoneVolunteer { get; private set; }
    public bool IsNeutered { get; private set; }
    public bool IsVaccinated { get; private set; }
    public PetAge PetAge { get; private set; }
    public PetHelpStatus HelpStatus { get; private set; }
    public PaymentDetails PaymentDetails { get; private set; }
    public DateTime CreatedAt { get; private set; }

    
    
    private Pet(
        PetId id, 
        Name name,
        SpeciesId speciesId, 
        Description description,
        PetGender gender,
        BreedId breedId,
        PetAddress address,
        PetColor color, 
        Description healthInformation, 
        PhoneNumber phoneVolunteer,
        PetSize petSize,
        PetAge petAge,
        PetHelpStatus helpStatus,
        PaymentDetails paymentDetails,
        bool isNeutered = false,
        bool isVaccinated = false) : base(id)
    {
        Id = id;
        Name = name;
        SpeciesId = speciesId;
        Description = description;
        PetGender = gender;
        BreedId = breedId;
        Address = address;
        Color = color;
        PetSize = petSize;
        HealthInformation = healthInformation;
        PhoneVolunteer = phoneVolunteer;
        PetAge = petAge;
        HelpStatus = helpStatus;
        PaymentDetails = paymentDetails;
        CreatedAt = DateTime.UtcNow;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
    }
}