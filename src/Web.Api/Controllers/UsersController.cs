using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (result.Success)
            {
                return Ok(result);

            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }
    }
}