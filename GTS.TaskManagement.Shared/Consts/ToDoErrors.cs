using GTS.TaskManagement.Shared.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GTS.TaskManagement.Shared.Consts
{
    public static class ToDoErrors
    {
        public static readonly Error NotFound
            = new("ToDo.NotFound", "ToDo not found", StatusCodes.Status404NotFound);

        public static readonly Error NotCreated
            = new("ToDo.NotCreated", "ToDo not created", StatusCodes.Status400BadRequest);

        public static readonly Error NotUpdated
            = new("ToDo.NotUpdated", "ToDo not updated", StatusCodes.Status400BadRequest);

        public static readonly Error NotDeleted
            = new(new("ToDo.NotDeleted", "ToDo not deleted", StatusCodes.Status400BadRequest);
    }
}
