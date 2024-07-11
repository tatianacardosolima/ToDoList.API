using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Domain.Checklists.Responses;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Checklists.Services
{
    public class ChecklistService: ServiceBase<ChecklistEntity, 
            UpdChecklistRequest, ChecklistResponse>, IChecklistService
    {
        public ChecklistService(IChecklistRepository repository, IChecklistFactory factory): base(repository, factory)
        {
            
        }
    }
}
