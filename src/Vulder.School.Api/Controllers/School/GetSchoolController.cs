using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[ApiController]
[Route("school/[controller]")]
public class GetSchoolController : ControllerBase
{
    private readonly IMediator _mediator;

    public GetSchoolController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSchool([FromQuery] Guid schoolId)
    {
        var school = await _mediator.Send(new GetSchoolModel
        {
            SchoolId = schoolId
        });

        return Ok(school);
    }
}