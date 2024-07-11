using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Requests
{
    public class ListRequest
    {
        public string Name{ get; set; }
    }

    public class NewListRequest: ListRequest, IRequest
    {        
    }

    public class IdNameListRequest : ListRequest, IRequest
    {
        public IdNameListRequest(string name)
        {
            Name = name;
        }
        public IdNameListRequest(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
    }
}
