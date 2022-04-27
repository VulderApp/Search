using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;
using Vulder.School.Core.ProjectAggregate.School.Dtos;

namespace Vulder.School.Api.Controllers.School;

[ApiController]
[Route("/school/find")]
public class FindSchoolsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FindSchoolsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> FindSchools([FromQuery] string input)
    {
        var result = await _mediator.Send(new FindSchoolModel
        {
            Input = input
        });

        if (result.Count == 0)
            return NoContent();

        var mappedResult  = _mapper.Map<SchoolItemDto[]>(result);

        return Ok(mappedResult);
    }
}