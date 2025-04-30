using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer;

public record TransferSocialNetworkList
{
    private readonly List<VolunteerSocialNetwork> _socialNetworks = new();
    public IReadOnlyList<VolunteerSocialNetwork> SocialNetworks => _socialNetworks;
    
    private TransferSocialNetworkList() {}

    private TransferSocialNetworkList(IEnumerable<VolunteerSocialNetwork> socialNetworks)
    {
        _socialNetworks = socialNetworks.ToList();
    }
    
    public void AddRequisitesForHelp(VolunteerSocialNetwork socialNetwork)
    {
        _socialNetworks.Add(socialNetwork);
    }

    public static Result<TransferSocialNetworkList> Create(IEnumerable<VolunteerSocialNetwork> socialNetworks) =>
        new TransferSocialNetworkList(socialNetworks);
}