using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Infrastructure.Write.Mappings
{
    public class ColumnsMapBase<TBase> :
         IEntityTypeConfiguration<TBase> where TBase : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd().IsRequired();
          
            builder
                .Property(x => x.CreatedAt)
                .IsRequired();

            builder
                .Property(x => x.ModifiedAt)
                .IsRequired(false);

            builder
             .Property(x => x.Active)
             .IsRequired(true);
        }
    }
}
