using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.Domain.Tasks.Interfaces
{
    public interface ITaskService: IService<TaskEntity,
            UpdTaskRequest, TaskResponse>
    {
        
        Task<DefaultResponse> ChangeStatus(UpdChangeStatusRequest request);
    }
}
