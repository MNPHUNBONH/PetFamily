using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Aggregates.Volunteer;

public record VolunteerSocialNetwork
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MAX_LINK_LENGTH = 100;
    public string Name { get;}
    public string Link { get;}

    private VolunteerSocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }

    public static Result<VolunteerSocialNetwork,Error> Create(string name, string link)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(link))
            return Errors.General.ValueIsInvalid("VolunteerSocialNetwork");
        
        if (name.Length > MAX_NAME_LENGTH || link.Length > MAX_LINK_LENGTH)
            return Errors.General.ValueIsRequired("VolunteerSocialNetwork");
             
        
        return new VolunteerSocialNetwork(name, link);
    }
}