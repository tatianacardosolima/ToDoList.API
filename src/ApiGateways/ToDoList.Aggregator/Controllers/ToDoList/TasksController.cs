using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Model;
using ToDoList.Aggregator.Services.TodoList;

namespace ToDoList.Aggregator.Controllers.ToDoList
{
    [ApiController]
    [Route("to-do-lists/tasks")]
    public class TasksController : TodoListBaseController<TaskModel, UpdTaskModel>
    {

        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger, ITaskService service): base(service,"/tasks")
        {
            _logger = logger;
        }

    }
}
