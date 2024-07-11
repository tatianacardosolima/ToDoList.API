using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Domain.Tasks.Enitities
{
    public enum WorkflowStatus { 
        TODO, DOING, DONE
    }
    public class TaskEntity: EntityBase
    {
        public TaskEntity():base()
        {            
        }
        public TaskEntity(ListEntity list, string title):base()
        {
            List = list;
            Title = title; 
            Status = WorkflowStatus.TODO;
        }

        public TaskEntity(ListEntity list, string title, string url) : base()
        {
            List = list;
            Title = title;
            URL = url;
            Status = WorkflowStatus.TODO;
        }

        public TaskEntity(ListEntity list, string title, string url, string description) : base()
        {
            List = list;
            Title = title;
            URL = url;
            Description = description;
            Status = WorkflowStatus.TODO;
        }

        public void AddList(ListEntity list) 
        {
            List = list;            
        }
        public void Change(string title, string url, string description) 
        {            
            Title = title;
            URL = url;
            Description = description;
            Status = WorkflowStatus.TODO;
            ModifiedAt = DateTime.Now;
        }

        public void AddPeriod(DateTime? startAt, DateTime? endAt)
        { 
            StartAt = startAt;
            EndAt = endAt;
        }

        public void GoNextStatus()
        { 
            if (Status == WorkflowStatus.TODO) 
                Status = WorkflowStatus.DOING;
            else if (Status == WorkflowStatus.DOING)
                Status = WorkflowStatus.DONE;            

        }

        public void ChangeStatus(WorkflowStatus status)
        {
            if (Status == status)
                throw new Exception();

            Status = status;
        }

        public ListEntity List { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string URL { get; private set; }

        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; private set; }

        public WorkflowStatus Status { get; set; }

        public override TaskResponse GetResponse()
        {
            return new TaskResponse { 
                Id = Id,
                Title = Title,
                StartAt = StartAt,
                EndAt = EndAt,
                Url = URL,
                Description = Description,

            };
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
