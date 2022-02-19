using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;

namespace Vulder.School.Api.Controllers.School;

[ApiController]
[Route("/school/[controller]")]
public class FindSchoolsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FindSchoolsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> FindSchools([FromQuery] string input)
    {
        var result = await _mediator.Send(new FindSchoolModel
        {
            Input = input
        });

        return Ok(result.Select(x => new SchoolItemDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList());
    }
}