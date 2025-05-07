using GTS.TaskManagement.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GTS.TaskManagement.Persistance.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<ToDo> MyProperty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
