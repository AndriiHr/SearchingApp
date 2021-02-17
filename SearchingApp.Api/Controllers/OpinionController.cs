using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchingApp.Application.Commands.Opinions;
using SearchingApp.Application.Queries.Opinions;
using System.Threading.Tasks;

namespace SearchingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpinionController: ControllerBase
    {
        private readonly IMediator _mediator;

        public OpinionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-per-project")]
        public async Task<IActionResult> GetProjects(GetProjectOpinionsQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetProjectDetails(GetOpinionDetailsQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("assing-opinion-to-project")]
        public async Task<IActionResult> AssignUserToProject(AssingOpinionToProjectCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditOpinion(EditOpinionCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOpinion(DeleteOpinionCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
