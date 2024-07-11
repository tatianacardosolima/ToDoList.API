using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Infrastructure.Write.Abstractions;
using ToDoList.Infrastructure.Write.Contexts;

namespace ToDoList.Infrastructure.Write.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity, Guid>, ITaskRepository
    {
        public TaskRepository(TodoListContext context):base(context)
        {            
        }
    }
}
