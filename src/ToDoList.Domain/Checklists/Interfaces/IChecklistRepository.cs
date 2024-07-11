using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Checklists.Interfaces
{
    public interface IChecklistRepository: IRepository<ChecklistEntity, Guid>
    {
    }
}
