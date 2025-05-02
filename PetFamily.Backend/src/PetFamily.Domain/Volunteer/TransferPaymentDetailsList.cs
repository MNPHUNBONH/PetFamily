using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer;
public record TransferPaymentDetailsList
{
    private readonly List<VolunteerPaymentDetails> _requisitesForPaymentDetails = new();
    public IReadOnlyList<VolunteerPaymentDetails> RequisitesForPaymentDetails => _requisitesForPaymentDetails;
    
    private TransferPaymentDetailsList() {}
    
    private TransferPaymentDetailsList(IEnumerable<VolunteerPaymentDetails> requisitesForPaymentDetails)
    {
        _requisitesForPaymentDetails = requisitesForPaymentDetails.ToList();
    }
    
    public void AddRequisitesForHelp(VolunteerPaymentDetails requisitesForHelp)
    {
        _requisitesForPaymentDetails.Add(requisitesForHelp);
    }

    public static Result<TransferPaymentDetailsList> Create(IEnumerable<VolunteerPaymentDetails> requisitesForHelps)
    {
        
        return new TransferPaymentDetailsList(requisitesForHelps);
    }
}