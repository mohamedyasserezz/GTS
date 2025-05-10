using AutoMapper;
using GTS.Domain.Specifications;
using GTS.TaskManagement.Domain.Common;
using GTS.TaskManagement.Domain.Contract.Persistance;
using GTS.TaskManagement.Domain.Contract.Services;
using GTS.TaskManagement.Domain.Entites;
using GTS.TaskManagement.Shared.Abstractions;
using GTS.TaskManagement.Shared.Consts;
using GTS.TaskManagement.Shared.Models;
using Microsoft.Extensions.Logging;

namespace GTS.Application.Services
{
    class ToDoServices(ILogger<ToDoServices> logger,
        IGenricRepository<ToDo> repository,
        IMapper mapper) : IToDoServices
    {
        private readonly ILogger<ToDoServices> _logger = logger;
        private readonly IGenricRepository<ToDo> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosAsync(CancellationToken cancellationToken = default, bool withTracking = false)
        {
            _logger.LogInformation("get all ToDo tasks");

            var todo = await _repository.GetAllAsync(withTracking, cancellationToken);

            var response = _mapper.Map<IEnumerable<ToDoResponse>>(todo);

            return Result.Success(response);
        }
        public async Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnPriorityAsync(ToDoPriorityFilter priorityFilter, CancellationToken cancellationToken = default, bool withTracking = false)
        {
            _logger.LogInformation("Getting all ToDo with priority: {priority}", priorityFilter.Priority);

            var specification = new Specification<ToDo>(x => x.Priority == Enum.Parse<Priority>(priorityFilter.Priority));

            var toDos = await _repository.GetAllWithSpecAsync(specification, withTracking, cancellationToken);

            var toDoResponses = _mapper.Map<IEnumerable<ToDoResponse>>(toDos);

            return Result.Success(toDoResponses);
        }

        public async Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnStatusAsync(ToDoStatusFilter statusFilter, CancellationToken cancellationToken = default, bool withTracking = false)
        {
            _logger.LogInformation("Getting all ToDo with status: {status}", statusFilter.Status);

            var specification = new Specification<ToDo>(x => x.Status == Enum.Parse<Status>(statusFilter.Status));

            var toDos = await _repository.GetAllWithSpecAsync(specification, withTracking, cancellationToken);

            var toDoResponses = _mapper.Map<IEnumerable<ToDoResponse>>(toDos);

            return Result.Success(toDoResponses);
        }
        public async Task<Result<ToDoResponse>> GetToDoByIdAsync(string id, CancellationToken cancellationToken = default, bool withTracking = false)
        {
            _logger.LogInformation($" getting ToDo By Id: {id}");

            if (await _repository.GetByIdAsync(id, cancellationToken) is not { } toDo)
            {
                _logger.LogInformation("the todo with id: {id} not found", id);
                return Result.Failure<ToDoResponse>(ToDoErrors.NotFound);
            }


            _logger.LogInformation("the todo with id: {id} found", id);
            var toDoResponse = _mapper.Map<ToDoResponse>(toDo);

            return Result.Success(toDoResponse);
        }
        public async Task<Result> CreateToDoAsync(ToDoRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("creating new todo");
            var toDoEntity = new ToDo
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = string.IsNullOrEmpty(request.DueDate) ? null : DateTime.Parse(request.DueDate),
                Priority = (Priority)Enum.Parse(typeof(Priority), request.Priority),
                Status = (Status)Enum.Parse(typeof(Status), request.Status),
            }; ;
            var result = await _repository.AddAsync(toDoEntity, cancellationToken);

            if (!result)
            {
                _logger.LogInformation("failed to create new todo");

                return Result.Failure(ToDoErrors.NotFound);
            }

            _logger.LogInformation("new todo task created");

            return Result.Success();

        }
        public async Task<Result> UpdateToDoAsync(ToDoUpdateRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("updateing todo task with id: {id}", request.Id);


            if (await _repository.GetByIdAsync(request.Id, cancellationToken) is not { } toDo)
            {
                _logger.LogInformation("the todo with id: {id} not found", request.Id);
                return Result.Failure(ToDoErrors.NotFound);
            }

            toDo.Title = request.Title;
            toDo.Description = request.Description;
            toDo.DueDate = string.IsNullOrEmpty(request.DueDate) ? null : DateTime.Parse(request.DueDate!);
            toDo.Priority = (Priority)Enum.Parse(typeof(Priority), request.Priority);
            toDo.Status = (Status)Enum.Parse(typeof(Status), request.Status);
            var result = _repository.Update(toDo);

            if (!result)
            {
                _logger.LogInformation("the todo with id: {id} not updated", request.Id);

                return Result.Failure(ToDoErrors.NotFound);
            }

            return Result.Success();
        }
        public async Task<Result> DeleteToDoAsync(string id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("deleting todo task with id: {id}", id);

            if (await _repository.GetByIdAsync(id, cancellationToken) is not { } toDo)
            {
                _logger.LogInformation("the todo with id: {id} not found", id);
                return Result.Failure(ToDoErrors.NotFound);
            }

            var result = _repository.Delete(toDo);

            if (!result)
            {
                _logger.LogInformation("the todo with id: {id} not deleted", id);

                return Result.Failure(ToDoErrors.NotFound);
            }

            _logger.LogInformation("the todo with id: {id} Deleted", id);
            return Result.Success();

        }

        public async Task<Result> ConvertToComplete(string id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Converting todo with id {id} to complete",id);


            if (await _repository.GetByIdAsync(id, cancellationToken) is not { } toDo)
            {
                _logger.LogInformation("the todo with id: {id} not found", id);
                return Result.Failure(ToDoErrors.NotFound);
            }
            toDo.Status = Status.Completed;

            var result = _repository.Update(toDo);

            if (!result)
            {
                _logger.LogInformation("failed to make it completed");

                return Result.Failure(ToDoErrors.NotUpdated);
            }
            _logger.LogInformation("todo completed successfully");

            return Result.Success();
        }
    }
}
