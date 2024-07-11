using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Responses;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Checklists.Entities
{
    public class ChecklistEntity: EntityBase
    {
        public ChecklistEntity():base()
        {            
        }
        public ChecklistEntity(TaskEntity task, string item) : base()
        {
            Task = task;
            Item = item;
        }
        public TaskEntity Task { get; set; }
        public string Item { get; set; }
        public bool Check { get; private set; } = false;

        

        public void Done()
        {
            Check = true;
        }

        public void NotDone()
        {
            Check = false;
        }

        public override ChecklistResponse GetResponse()
        {
            return new ChecklistResponse()
            {
                Id = Id,
                Check = Check,
                Item = Item
            };
        }
    }
}
