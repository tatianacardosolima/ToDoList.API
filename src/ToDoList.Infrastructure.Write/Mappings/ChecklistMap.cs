using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;

namespace ToDoList.Infrastructure.Write.Mappings
{
    public class ChecklistMap: ColumnsMapBase<ChecklistEntity>
    {
        public override void Configure(EntityTypeBuilder<ChecklistEntity> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Item).IsRequired(true).HasMaxLength(180);
            builder.Property(x => x.Check).IsRequired(true);
        }
    }
}
