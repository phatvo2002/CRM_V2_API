using CRM.Application.Features.V1.SystemManagements.Department.Command;
using CRM.Application.Features.V1.SystemManagements.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBranch([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole([FromBody] DeleteUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
