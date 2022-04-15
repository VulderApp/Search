using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[Authorize]
[ApiController]
[Route("/school/delete")]
public class DeleteController : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSchool([FromQuery] Guid schoolId)
    {
        var result = await _mediator.Send(new DeleteSchoolModel
        {
            Id = schoolId
        });

        return Ok(result);
    }
}