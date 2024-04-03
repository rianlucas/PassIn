using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Infrastructure;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(typeof(ResponseRegisterEventJson), StatusCodes.Status201Created)]
[ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
public class EventController : ControllerBase
{

    [HttpPost]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        var useCase = new RegisterEventUseCase();
        var response = useCase.Execute(request);
        
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var useCase = new GetEventByIdUseCase();
        
        var response = useCase.Execute(id);
        
        return Ok();
    }
}

