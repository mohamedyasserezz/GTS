namespace GTS.TaskManagement.Shared.Models
{
    public record ToDoUpdateRequest(
        string Id,
        string Title,
        string? Description,
        string Priority,
        string Status,
        DateTime? DueDate
        );
}
