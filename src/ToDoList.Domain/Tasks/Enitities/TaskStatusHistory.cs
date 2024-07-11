using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Tasks.Enitities
{
    public class TaskStatusHistory: EntityBase
    {
        public Task Task { get; set; }
        public WorkflowStatus Status { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public override ResponseBase GetResponse()
        {
            throw new NotImplementedException();
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
