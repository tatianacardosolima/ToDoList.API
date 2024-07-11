using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Checklists.Responses
{
    public class ChecklistResponse: ResponseBase
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public bool Check { get; set; } = false;
    }
}
