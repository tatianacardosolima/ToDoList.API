using ToDoList.Aggregator.Abstractions;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Aggregator.Model;

namespace ToDoList.Aggregator.Services
{
    public interface IListService : IToDoListService<ListModel, UpdListModel>
    { 
    
    }
    public class ListService: TodoListBaseService<ListModel, UpdListModel>, IListService
    {        

        public ListService(HttpClient client) : base(client)
        {        
        }
        
    }
}
