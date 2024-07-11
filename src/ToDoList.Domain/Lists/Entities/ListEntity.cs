using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Responses;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Entities
{
    public class ListEntity: EntityBase
    {
        public string Name { get; private set; }

        public ListEntity(string name): base()
        {
            Name = name;
        }
        public ListEntity() 
        {            
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public override ListResponse GetResponse()
        {
            return new ListResponse()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
