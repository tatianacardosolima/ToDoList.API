using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.TodoList.Interfaces;
using ToDoList.Domain.TodoList.Queries;

namespace ToDoList.Domain.TodoList.Services
{
    public class TodoListService : IToDoListService
    {
        private readonly ITodoListProvider _provider;

        public TodoListService(ITodoListProvider provider)
        {
            _provider = provider;
        }
        public async Task<List<ListQuery>> GetAll()
        {
            return await _provider.GetAllListAsync();
        }

        public async Task<List<TaskQuery>> GetTasksByListAsync(Guid listid)
        {
            return await _provider.GetAllTaskByListAsync(listid);
        }
    }
}
