using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Factories;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Lists.Responses;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Services
{
    public class ListService : ServiceBase<ListEntity,
            IdNameListRequest,  ListResponse>, IListService
    {
        public ListService(IListRepository repository, 
                           IListFactory factory) 
            : base(repository, factory)
        {
        }

        public Task<List<TaskResponse>> GetByListAsync(Guid listid)
        {
            throw new NotImplementedException();
        }
    }
}
