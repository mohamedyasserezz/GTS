using GTS.TaskManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace GTS.TaskManagement.Persistance.Data.Interceptor
{
    internal class AuditInterceptor : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            UpdateEntities(eventData.Context);

            return base.SavedChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavedChangesAsync(eventData, result, cancellationToken);
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
