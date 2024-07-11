using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Domain.Checklists.Responses;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Lists.Responses;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Checklists.Interfaces
{
    public interface IChecklistService: IService<ChecklistEntity,
            UpdChecklistRequest, ChecklistResponse>
    {
    }
}
