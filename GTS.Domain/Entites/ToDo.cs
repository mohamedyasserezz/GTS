using GTS.ToDo.Domain.Common;

namespace GTS.ToDo.Domain.Entites
{
    public class ToDo : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
