using interview_tallertechnologies.Application.UseCases.User.v1.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace interview_tallertechnologies.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-username/{username}")]
        [ProducesResponseType(typeof(GetUserByUserNameQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByUsernameAsyc(string username)
        {
            var query = new GetUserByUserNameQuery(username);
            var result = await _mediator.Send(query);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
