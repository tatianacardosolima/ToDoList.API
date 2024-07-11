using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Infrastructure.Write.Mappings;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Infrastructure.Write.Contexts
{
    public class TodoListContext: DbContext
    {
        public string UserId { get; set; }
        public TodoListContext(DbContextOptions<TodoListContext> options,
               string userId
            ) : base(options)
        {            
            UserId = userId;            
        }

        public DbSet<ChecklistEntity> Checklist { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<ListEntity> List { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ChecklistMap());
            builder.ApplyConfiguration(new ListMap());
            builder.ApplyConfiguration(new TaskMap());
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {        
            return base.SaveChangesAsync(true, cancellationToken);
        }

        
    }
}
