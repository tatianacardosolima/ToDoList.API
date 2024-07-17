using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Model;
using ToDoList.Aggregator.Services.TodoList;

namespace ToDoList.Aggregator.Controllers.ToDoList
{
    [ApiController]
    [Route("to-do-list/tasks")]
    public class ChecklistController : TodoListBaseController<TaskModel, UpdTaskModel>
    {

        private readonly ILogger<TasksController> _logger;

        public ChecklistController(ILogger<TasksController> logger, ITaskService service): base(service,"/checklists")
        {
            _logger = logger;
        }

    }
}
