using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Infrastructure.Write.Abstractions;
using ToDoList.Infrastructure.Write.Contexts;

namespace ToDoList.Infrastructure.Write.Repositories
{
    public class ChecklistRepository: RepositoryBase<ChecklistEntity,Guid> , IChecklistRepository
    {
        public ChecklistRepository(TodoListContext context) : base(context)
        {            
        }
    }
}
