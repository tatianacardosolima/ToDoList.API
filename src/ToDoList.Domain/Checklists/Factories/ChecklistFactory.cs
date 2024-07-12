using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Checklists.Factories
{
    public class ChecklistFactory: IChecklistFactory
    {
        private readonly IChecklistRepository _repository;
        private readonly ITaskRepository _taskRepository;

        public ChecklistFactory(IChecklistRepository repository, ITaskRepository taskRepository)
        {
            _repository = repository;
            _taskRepository = taskRepository;
        }
        public async Task<ChecklistEntity> CreateAsync(UpdChecklistRequest request)
        {
            ChecklistEntity entity = null;
            if (request.Id != null && request.Id != Guid.Empty)
            {
                entity = await _repository.GetByIdAsync(request.Id);
                entity.ChangeItem(request.Item);
            }
            else 
            {
                var entityTask = await _taskRepository.GetByIdAsync(request.TaskId);
                entity = new ChecklistEntity(entityTask, request.Item);
            }
            entity.Validate();
            return entity;
        }
    }
}
