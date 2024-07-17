using Common.Shared.Enums;
using ToDoList.Aggregator.Interfaces;

namespace ToDoList.Aggregator.Model
{
    public class TaskModel: IModel
    {
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public WorkflowStatus Status { get; set; }
    }
    public class UpdTaskModel : TaskModel, IModel
    {
        public Guid Id { get; set; }
    }
}
