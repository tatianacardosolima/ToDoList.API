using Microsoft.Win32;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Responses;

namespace ToDoList.Domain.Tasks.Services
{
    public class TaskService : ServiceBase<TaskEntity,
            UpdTaskRequest, TaskResponse>, ITaskService
    {
        public TaskService(ITaskRepository repository,
                          ITaskFactory factory):base(repository, factory)
        {

        }

        public async Task<DefaultResponse> ChangeStatus(UpdChangeStatusRequest request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            entity.ChangeStatus(request.Status);            
            await _repository.SaveChangesAsync();
            return new DefaultResponse(true, "Situação alterada com sucesso.");
        }

    }
}
