using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Checklists.Requests
{
    public class ChecklistRequest
    {
        public Guid TaskId { get; set; }
        public string Item { get; set; }
        public bool Check { get; set; } = false;
    }

    public class NewChecklistRequest:ChecklistRequest, IRequest
    {     
    }

    public class UpdChecklistRequest : ChecklistRequest, IRequest
    {
        public UpdChecklistRequest()
        {            
        }
        public UpdChecklistRequest(Guid id, string item)
        {
            Id = id;
            
            Item = item;
        }
        public Guid Id { get; set; }
    }
}
