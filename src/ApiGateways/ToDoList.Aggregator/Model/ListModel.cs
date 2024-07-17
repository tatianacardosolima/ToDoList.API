using ToDoList.Aggregator.Interfaces;

namespace ToDoList.Aggregator.Model
{
    public class ListModel: IModel
    {
        public string Name { get; set; }
    }
    public class UpdListModel : ListModel, IModel
    {
        public Guid Id { get; set; }

    }
}
