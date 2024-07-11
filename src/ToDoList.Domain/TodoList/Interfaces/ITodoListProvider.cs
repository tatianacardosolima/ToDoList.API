using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.TodoList.Queries;

namespace ToDoList.Domain.TodoList.Interfaces
{
    public interface ITodoListProvider
    {
        Task<List<ListQuery>> GetAllListAsync();

        Task<List<TaskQuery>> GetAllTaskByListAsync(Guid id);
    }
}
