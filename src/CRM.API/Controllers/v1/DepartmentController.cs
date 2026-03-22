using CRM.Application.Features.V1.SystemManagements.Department.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreateBranch([FromBody] CreateDepartmentCommad command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateDepartmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole([FromBody] DeleteDepartmentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
