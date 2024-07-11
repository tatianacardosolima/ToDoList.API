using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Tasks.Enitities;

namespace ToDoList.Infrastructure.Write.Mappings
{
    public class TaskMap: ColumnsMapBase<TaskEntity>
    {
        public override void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(120);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.URL).IsRequired(false).HasMaxLength(2083);
            builder.Property(x => x.StartAt).IsRequired(false);
            builder.Property(x => x.EndAt).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}
