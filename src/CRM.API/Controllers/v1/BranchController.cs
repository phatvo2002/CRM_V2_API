using CRM.Application.Features.V1.SystemManagements.Branch.Command;
using CRM.Application.Features.V1.SystemManagements.Branch.Query;
using CRM.Application.Features.V1.SystemManagements.Role.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllBranchQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<ActionResult> CreateBranch([FromBody] CreateBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole([FromBody] DeleteBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
