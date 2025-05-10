using GTS.TaskManagement.Domain.Entites;
using GTS.TaskManagement.Shared.Abstractions;
using GTS.TaskManagement.Shared.Models;
namespace GTS.TaskManagement.Domain.Contract.Services
{
    public interface IToDoServices
    {
        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosAsync(CancellationToken cancellationToken = default, bool withTracking = false);

        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnPriorityAsync(ToDoPriorityFilter priorityFilter, CancellationToken cancellationToken = default, bool withTracking = false);
        Task<Result<IEnumerable<ToDoResponse>>> GetAllToDosBasedOnStatusAsync(ToDoStatusFilter statusFilter, CancellationToken cancellationToken = default, bool withTracking = false);
        Task<Result<ToDoResponse>> GetToDoByIdAsync(string id, CancellationToken cancellationToken = default, bool withTracking = false);
        Task<Result> CreateToDoAsync(ToDoRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateToDoAsync(ToDoUpdateRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteToDoAsync(string id, CancellationToken cancellationToken = default);
        Task<Result> ConvertToComplete(string id, CancellationToken cancellationToken = default);
    }
}
