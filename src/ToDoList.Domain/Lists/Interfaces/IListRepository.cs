using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Interfaces
{
    public interface IListRepository: IRepository<ListEntity, Guid>
    {
    }
}
