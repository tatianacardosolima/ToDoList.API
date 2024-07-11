using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Lists.Responses;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Interfaces
{
    public interface IListService : IService<ListEntity,
            UpdListRequest, ListResponse>
    {
        
    }
}
