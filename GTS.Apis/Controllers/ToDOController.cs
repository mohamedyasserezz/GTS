using GTS.TaskManagement.Domain.Contract.Services;
using GTS.TaskManagement.Shared.Abstractions;
using GTS.TaskManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GTS.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDOController(IToDoServices toDoServices) : ControllerBase
    {
        private readonly IToDoServices _toDoServices = toDoServices;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.GetToDoByIdAsync(id, cancellationToken);

            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _toDoServices.GetAllToDosAsync(cancellationToken);

            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetBasedOnStatus([FromQuery]ToDoStatusFilter statusFilter, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.GetAllToDosBasedOnStatusAsync(statusFilter, cancellationToken);

            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }

        [HttpGet("priority")]
        public async Task<IActionResult> GetBasedOnPriority([FromQuery]ToDoPriorityFilter priorityFilter, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.GetAllToDosBasedOnPriorityAsync(priorityFilter, cancellationToken);

            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoRequest request, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.CreateToDoAsync(request, cancellationToken);

            return result.IsSuccess ? Created() : result.ToProblem();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ToDoUpdateRequest request, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.UpdateToDoAsync(request, cancellationToken);

            return result.IsSuccess ? Created() : result.ToProblem();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delted([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.DeleteToDoAsync(id, cancellationToken);

            return result.IsSuccess ? Created() : result.ToProblem();
        }
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _toDoServices.ConvertToComplete(id, cancellationToken);

            return result.IsSuccess ? Created() : result.ToProblem();
        }
    }
}
