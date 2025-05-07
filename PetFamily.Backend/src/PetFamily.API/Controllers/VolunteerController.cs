using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.API.Response;
using PetFamily.Application.Volunteers.Commands;
using PetFamily.Application.Volunteers.CreateVolunteer;


namespace PetFamily.API.Controllers;

public class VolunteerController : ApplicationController
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var commandHandler = new CreateVolunteerCommand(
            request.VolunteerFullName,
            request.Email,
            request.Description,
            request.Experience,
            request.Phone,
            request.SocialNetwork,
            request.PaymentDetails);
        
        var result = await handler.Handler(commandHandler, cancellationToken);
        
        return result.ToResponse();

        
    }
}