using FluentValidation;
using PetFamily.Application.Volunteers;
using PetFamily.Application.Volunteers.Commands;
using PetFamily.Domain.Aggregates.Volunteer;
using PetFamily.Domain.Shared.ValueObject;

namespace PetFamily.Application.Validation;

public class CreateVolunteerCommandValidator : AbstractValidator<CreateVolunteerCommand>
{
    public CreateVolunteerCommandValidator()
    {
        RuleFor(c => c.VolunteerFullName)
            .MustBeValueObject(x=> VolunteerFullName.Create(x.FirstName, x.LastName));
        RuleFor(c => c.Email).MustBeValueObject(VolunteerEmail.Create);
        RuleFor(c => c.Description).MustBeValueObject(Description.Create);
        RuleFor(c => c.Experience).MustBeValueObject(VolunteerExperience.Create);
        RuleFor(c=>c.Phone).MustBeValueObject(PhoneNumber.Create);

        RuleForEach(c => c.SocialNetworks).MustBeValueObject(s => VolunteerSocialNetwork.Create(s.Name, s.Link));
        RuleForEach(c => c.PaymentDetails).MustBeValueObject(p => VolunteerPaymentDetails.Create(p.Name, p.Description));

        RuleForEach(c => c.SocialNetworks)
            .ChildRules(sn => sn
                .RuleFor(s => new { s.Name, s.Link })
                .MustBeValueObject(v=>VolunteerSocialNetwork.Create(v.Name, v.Link)));
        
        RuleForEach(c => c.PaymentDetails)
            .ChildRules(pd => pd
                .RuleFor(d => new { d.Name, d.Description })
                .MustBeValueObject(v=>VolunteerPaymentDetails.Create(v.Name, v.Description)));

    }
}


