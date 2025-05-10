using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS.TaskManagement.Shared.Models
{
    public record ToDoRequest(
    string Title,
    string? Description,
    string Priority,
    string Status,
    string? DueDate
    );
}
