using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Model;
using ToDoList.Aggregator.Services.TodoList;

namespace ToDoList.Aggregator.Controllers.ToDoList
{
    [ApiController]
    [Route("to-do-list/lists")]
    public class LististController : TodoListBaseController<ListModel, UpdListModel>
    {

        private readonly ILogger<TasksController> _logger;

        public LististController(ILogger<TasksController> logger, IListService service): base(service,"/lists")
        {
            _logger = logger;
        }

    }
}
