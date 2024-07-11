using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Tasks.Services
{
    public class TaskService : ServiceBase<TaskEntity,
            UpdTaskRequest, TaskResponse>, ITaskService
    {
        public TaskService(ITaskRepository repository,
                          ITaskFactory factory):base(repository, factory)
        {

        }

        public Task<List<TaskResponse>> GetByListAsync(Guid listid)
        {
            throw new NotImplementedException();
        }
    }
}
