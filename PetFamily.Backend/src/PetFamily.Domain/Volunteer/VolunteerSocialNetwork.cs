using CSharpFunctionalExtensions;

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
             return Result.Failure<VolunteerSocialNetwork>("Name is not null or empty");
        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<VolunteerSocialNetwork>("Link is not null or empty");
        
        return new VolunteerSocialNetwork(name, link);
    }
}