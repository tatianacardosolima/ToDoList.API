using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Tasks.Interfaces
{
    public interface ITaskRepository: IRepository<TaskEntity, Guid>
    {
    }
}
