using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Tasks.Requests
{
    public class TaskRequest
    {
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public WorkflowStatus Status { get; set; }
    }

    public class NewTaskRequest : TaskRequest, IRequest
    {        
    }

    public class UpdTaskRequest : TaskRequest, IRequest
    {
        public Guid Id { get; set; }
    }
}
