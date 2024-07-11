using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Infrastructure.Write.Abstractions;
using ToDoList.Infrastructure.Write.Contexts;

namespace ToDoList.Infrastructure.Write.Repositories
{
    public class ListRepository: RepositoryBase<ListEntity, Guid>, IListRepository
    {
        public ListRepository(TodoListContext context):base(context)
        {            
        }
    }
}
