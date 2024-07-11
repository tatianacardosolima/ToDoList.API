using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.TodoList.Queries;

namespace ToDoList.Domain.TodoList.Interfaces
{
    public interface IToDoListService
    {
        Task<List<TaskQuery>> GetTasksByListAsync(Guid listid);

        Task<List<ListQuery>> GetAll();
    }
}
