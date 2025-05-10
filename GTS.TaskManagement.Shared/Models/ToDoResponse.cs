namespace GTS.TaskManagement.Shared.Models
{
    public record ToDoResponse(
        string Id,
        string Title,
        string? Description,
        string Priority,
        string Status,
        DateTime? DueDate, 
        DateTime CreatedDate,
        DateTime LastModifiedDate
    );
}
