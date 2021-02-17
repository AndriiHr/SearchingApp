using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchingApp.Application.Queries.Users;
using System.Threading.Tasks;
using SearchingApp.Application.Commands;

namespace SearchingApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-with-filter")]
        public async Task<IActionResult> GetActiveUsers(GetActiveUsersQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetUserDetails(GetUserDetailsQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> CreateUser(EditUserRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}