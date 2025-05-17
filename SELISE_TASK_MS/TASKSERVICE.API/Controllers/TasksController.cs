using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TASKSERVICE.Core.DTOs;
using TASKSERVICE.Core.Tasks;

namespace TASKSERVICE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto task)
        {
            var taskId = await _mediator.Send(new CreateTaskCommand(task));
            return CreatedAtAction(nameof(GetById), new { id = taskId }, null);
        }

        [Authorize(Roles = "Employee")]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string newStatus)
        {
            var result = await _mediator.Send(new UpdateTaskStatusCommand { TaskId = id, Status = newStatus });
            return result ? Ok("Status updated.") : NotFound();
        }

        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetTasksQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(); // Placeholder
    }

}
