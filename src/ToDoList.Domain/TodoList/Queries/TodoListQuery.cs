using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.TodoList.Queries
{
    public class TodoListQuery
    {

        public Guid ListId { get; set; }
        public string Name { get; set; }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public Guid ChecklistId { get; set; }
        public string Item { get; set; }
        public bool Check { get; set; }
    }
    public class ListQuery
    {
        public ListQuery()
        {
            Tasks = new List<TaskQuery>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TaskQuery> Tasks { get; set; }
    }

    public class TaskQuery
    {
        public TaskQuery()
        {
            Checklists = new List<ChecklistQuery>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<ChecklistQuery> Checklists { get; set; }

    }
    public class ChecklistQuery
    {
        
        public Guid Id { get; set; }
        public string Item { get; set; }
        public bool Check { get; set; }

    }

}
