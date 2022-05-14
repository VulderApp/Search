using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.School.Core.Models;

namespace Vulder.School.Api.Controllers.School;

[Authorize]
[ApiController]
[Route("/school/add")]
public class AddSchoolController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AddSchoolController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddSchool([FromBody] AddSchoolModel addSchoolModel)
    {
        var school = await _mediator.Send(
            _mapper.Map<Core.ProjectAggregate.School.School>(addSchoolModel)
        );

        return Ok(school);
    }
}