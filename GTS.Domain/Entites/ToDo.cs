using GTS.TaskManagement.Domain.Common;

namespace GTS.TaskManagement.Domain.Entites
{
    public class ToDo : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public DateTime? DueDate { get; set; } 
    }
}
