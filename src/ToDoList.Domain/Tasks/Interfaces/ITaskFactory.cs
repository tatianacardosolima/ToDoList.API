using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Tasks.Interfaces
{
    public interface ITaskFactory: IFactory<UpdTaskRequest, TaskEntity>
    {
        Task<TaskEntity> CreateAsync(UpdTaskRequest request);
    }
}
