using CRM.Application.Features.V1.SystemManagements.Role.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole([FromBody] DeleteRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
