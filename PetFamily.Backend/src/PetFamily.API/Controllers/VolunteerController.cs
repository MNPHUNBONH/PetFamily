using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.API.Response;
using PetFamily.Application.Volunteers.CreateVolunteer;


namespace PetFamily.API.Controllers;

[ApiController] 
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]

    public async Task< ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler, 
        [FromBody] CreateVolunteerRequest request, 
        CancellationToken cancellationToken = default)
    {
        //вызов сервис для создания модуля(вызов бизнес логика)
         var result = await handler.Handler(request, cancellationToken);

         if (result.IsFailure)
             return result.Error.ToResponse();
         
        return Ok(Envelope.Ok(result.Value)); 
     }
    
}