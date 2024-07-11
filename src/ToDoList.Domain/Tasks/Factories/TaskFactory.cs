using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;

namespace ToDoList.Domain.Tasks.Factories
{
    public class TaskFactory : ITaskFactory
    {
        private readonly ITaskRepository _repository;
        private IListRepository _listRepository;

        public TaskFactory(ITaskRepository repository, IListRepository listRepository)
        {
            _repository = repository;
            _listRepository = listRepository;
        }
        public async Task<TaskEntity> CreateAsync(UpdTaskRequest request)
        {
            var entity = new TaskEntity();
            var entityList = new ListEntity();
            if (request.Id != null && request.Id != Guid.Empty)
            {
                entity = await _repository.GetByIdAsync(request.Id);
            }
            else 
            {
                entityList = await _listRepository.GetByIdAsync(request.ListId);
                entity.AddList(entityList);
                entity.ChangeStatus(WorkflowStatus.TODO);

            }

            entity.Change(request.Title, request.URL, request.Description);
            entity.AddPeriod(request.StartAt, request.EndAt);
            entity.Validate();
            return entity;
        }
    }
}
