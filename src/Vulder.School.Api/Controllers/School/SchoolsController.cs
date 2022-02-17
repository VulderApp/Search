using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[Authorize]
[ApiController]
[Route("school/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public SchoolsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Schools([FromQuery] int page = 1)
    {
        var result = _mediator.Send(new SchoolsModel
        {
            Page = page
        });

        return Ok();
    }
}