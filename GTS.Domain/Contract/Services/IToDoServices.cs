using GTS.TaskManagement.Domain.Entites;
using GTS.TaskManagement.Shared.Abstractions;
using GTS.TaskManagement.Shared.Models;
namespace GTS.TaskManagement.Domain.Contract.Services
{
    public interface IToDoServices
    {
        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosAsync(bool withTracking = false, CancellationToken cancellationToken = default);

        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnPriorityAsync(ToDoPriorityFilter priorityFilter, bool withTracking = false, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnStatusAsync(ToDoStatusFilter statusFilter, bool withTracking = false, CancellationToken cancellationToken = default);
        Task<Result<ToDoResponse>> GetToDoByIdAsync(string id, bool withTracking = false, CancellationToken cancellationToken = default);
        Task<Result> CreateToDoAsync(ToDoRequest toDo, CancellationToken cancellationToken = default);
        Task<Result> UpdateToDoAsync(ToDoUpdateRequest toDo, CancellationToken cancellationToken = default);
        Task<Result> DeleteToDoAsync(string id, CancellationToken cancellationToken = default);
    }
}
