using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchingApp.Application.Commands.Projects;
using SearchingApp.Application.Queries.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetProjects(GetProjectsQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetProjectDetails(GetProjectDetailsQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject(CreateProjectCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("assing-project-to-user")]
        public async Task<IActionResult> AssignUserToProject(AssignProjectToUserCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditProject(EditProjectCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProject(DeleleProjectCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }
}
