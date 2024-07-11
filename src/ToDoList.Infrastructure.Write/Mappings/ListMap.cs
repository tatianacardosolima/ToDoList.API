using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Enitities;

namespace ToDoList.Infrastructure.Write.Mappings
{
    public class ListMap: ColumnsMapBase<ListEntity>
    {
        public override void Configure(EntityTypeBuilder<ListEntity> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(120);
            
        }
    }
}
