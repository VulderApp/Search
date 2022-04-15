using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[ApiController]
[Authorize]
[Route("/school/update")]
public class UpdateSchoolController : ControllerBase
{
    private readonly IMediator _mediator;

    public UpdateSchoolController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSchool([FromBody] UpdateSchoolModel updateSchoolModel)
    {
        var result = await _mediator.Send(updateSchoolModel);

        return Ok(result);
    }
}