using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Lists.Responses
{
    public class ListResponse: ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
