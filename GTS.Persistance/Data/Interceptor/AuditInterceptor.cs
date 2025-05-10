using GTS.TaskManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace GTS.TaskManagement.Persistance.Data.Interceptor
{
    internal class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? dbContext)
        {
            if (dbContext == null)
                return;
            var entries = dbContext.ChangeTracker.Entries<BaseAuditableEntity>().
                   Where(entry => entry.State is EntityState.Added or EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
            }

        }
    }
}
