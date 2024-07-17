using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Model;
using ToDoList.Aggregator.Services;

namespace ToDoList.Aggregator.Controllers.ToDoList
{
    [ApiController]
    [Route("to-do-list/lists")]
    public class LististController : TodoListBaseController<TaskModel, UpdTaskModel>
    {

        private readonly ILogger<TasksController> _logger;

        public LististController(ILogger<TasksController> logger, ITaskService service): base(service,"/lists")
        {
            _logger = logger;
        }

    }
}
