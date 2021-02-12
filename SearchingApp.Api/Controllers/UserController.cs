using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchingApp.Application.Queries.Users;
using System.Threading.Tasks;
using SearchingApp.Application.Commands;
using SearchingApp.DDD.Entities.Shared;
using SearchingApp.DDD.Entities.User;

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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetActiveUsers()
        {

            var request = new GetActiveUsersQuery()
            {
                Technologies = new List<Technology>(),
                PageNumber = 1,
                PageSize = 10
            };
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // [HttpGet]
        // public async Task<IActionResult> GetUserDetails(GetUserDetailsQuery request)
        // {
        //     var response = await _mediator.Send(request);
        //
        //     return Ok(response);
        // }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            request.User = new User("Andrew 1", "Hrytsiuk 1", "test@gmaiil.com", Role.Developer);

            var t = new List<Technology>() {
                new Technology()
                {
                    IsActive = true,
                    TechnologyPart = Technologies.Angular,
                    Description = "angular"
                },
                 new Technology()
                {
                    IsActive = true,
                    TechnologyPart = Technologies.CSharp,
                    Description = "c#"
                },

            };
            t.ForEach(x => request.User.AddTechnology(x));


            await _mediator.Send(request);
            return Ok();
        }
    }
}