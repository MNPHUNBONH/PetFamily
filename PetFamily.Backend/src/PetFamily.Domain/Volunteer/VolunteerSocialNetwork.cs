

using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;

public record VolunteerSocialNetwork
{
    public string Name { get;}
    public string Link { get;}

    private VolunteerSocialNetwork(string name, string link)
    {
        Name = name;
        Link = link;
    }

    public Result<VolunteerSocialNetwork> Create(string name, string link)
    {
        if (string.IsNullOrWhiteSpace(name))
             return "Name is not null or empty";
        if (string.IsNullOrWhiteSpace(link))
            return "Link is not null or empty";
        
        return new VolunteerSocialNetwork(name, link);
    }
}