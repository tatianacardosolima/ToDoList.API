using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Aggregator.Model;

namespace ToDoList.Aggregator.Services
{
    public interface ITaskService: IToDoListService<TaskModel, UpdTaskModel>
    {
    }
    public class TaskService : TodoListBaseService<TaskModel, UpdTaskModel>, ITaskService
    {
        public TaskService(HttpClient client) : base(client)
        {
        }
    }
}
