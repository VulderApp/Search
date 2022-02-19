using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[Authorize]
[ApiController]
[Route("/school/[controller]")]
public class FindSchoolsWithPaginationController : ControllerBase
{
    private readonly IMediator _mediator;

    public FindSchoolsWithPaginationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> FindSchoolsWithPagination([FromQuery] string input, [FromQuery] int page = 1)
    {
        var result = await _mediator.Send(new FindSchoolsPaginationModel
        {
            Input = input,
            Page = page
        });

        return Ok(result);
    }
}