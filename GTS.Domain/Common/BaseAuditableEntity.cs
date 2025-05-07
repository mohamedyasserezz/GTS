namespace GTS.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
