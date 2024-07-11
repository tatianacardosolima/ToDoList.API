using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Tasks.Responses
{
    public class TaskResponse: ResponseBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt{ get; set; }
    }
}
