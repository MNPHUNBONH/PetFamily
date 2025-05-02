using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteer.Pet;
public class Pet : Shared.Entity<PetId>
{
    //EF Core
    private Pet(PetId id) : base(id)
     {
     } 
    
    public Title Title { get; private set; }
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
    public VolunteerPaymentDetails VolunteerPaymentDetails { get; private set; }
    public DateTime CreatedAt { get; private set; }

    
    
    private Pet(
        PetId id, 
        Title title,
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
        VolunteerPaymentDetails volunteerPaymentDetails,
        bool isNeutered ,
        bool isVaccinated ): base(id)
    {
        Title = title;
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
        VolunteerPaymentDetails = volunteerPaymentDetails;
        CreatedAt = DateTime.UtcNow;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
    }

    public static Result<Pet, Error> Create(
        PetId id,
        Title title,
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
        VolunteerPaymentDetails volunteerPaymentDetail,
        bool isNeutered = false,
        bool isVaccinated = false)
    {
        return new Pet(id,
            title,
            speciesId,
            description,
            gender,
            breedId,
            address,
            color,
            healthInformation,
            phoneVolunteer,
            petSize,
            petAge,
            helpStatus,
            volunteerPaymentDetail,
            isNeutered,
            isVaccinated);
    }
 }