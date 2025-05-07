using GTS.TaskManagement.Domain.Common;
using GTS.TaskManagement.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS.Persistance.Data.Configurations
{
    public class ToDoConfigurations : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Priority)
                .HasConversion(

                    T => T.ToString(),
                    t => (Priority)System.Enum.Parse(typeof(Priority), t)
                );

            builder.Property(x => x.Status)
                .HasConversion(

                    T => T.ToString(),
                    t => (Status)System.Enum.Parse(typeof(Status), t)
                );



        }
    }

}
