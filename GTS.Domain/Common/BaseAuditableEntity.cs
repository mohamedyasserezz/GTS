namespace GTS.TaskManagement.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; }
    }
}
