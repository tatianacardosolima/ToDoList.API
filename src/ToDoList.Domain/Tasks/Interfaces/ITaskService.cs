using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Tasks.Interfaces
{
    public interface ITaskService: IService<TaskEntity,
            UpdTaskRequest, TaskResponse>
    {
        Task<List<TaskResponse>> GetByListAsync(Guid listid);
    }
}
