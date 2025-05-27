using CSharpFunctionalExtensions;
using PetFamily.Domain.Aggregates.Volunteer;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers ;

public interface IVolunteersRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
    Task<Result<Volunteer,Error>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default);
    Task<Result<Volunteer,Error>> GetByEmail(VolunteerEmail email, CancellationToken cancellationToken = default); 
}