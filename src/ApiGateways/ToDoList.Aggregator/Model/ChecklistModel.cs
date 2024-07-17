using ToDoList.Aggregator.Interfaces;

namespace ToDoList.Aggregator.Model
{
    public class ChecklistModel: IModel
    {        
        public Guid TaskId { get; set; }
        public string Item { get; set; }
        public bool Check { get; set; } = false;
    }
    public class UpdChecklistModel: ChecklistModel, IModel
    {
        public Guid Id { get; set; }
        
    }
}
