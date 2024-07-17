using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Aggregator.Model;

namespace ToDoList.Aggregator.Services
{
    public interface IChecklistService: IToDoListService<ChecklistModel, UpdChecklistModel>
    {

    }
    public class ChecklistService : TodoListBaseService<ChecklistModel, UpdChecklistModel>, IChecklistService
    {


        public ChecklistService(HttpClient client) : base(client)
        {
        }
    }
}
