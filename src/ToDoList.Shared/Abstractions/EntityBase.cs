using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Interfaces;
using ToDoList.Shared.Records;

namespace ToDoList.Shared.Abstractions
{
    public abstract class EntityBase: IEntity
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
        public bool Active { get; protected set; } = true;

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
            Active = true;
        }

        public bool IsActive()
        {
            return Active;
        }
        public void Inactivate()
        {
            //EntityInactiveException.ThrowWhenIsInactive(this, "The entity has already been deleted");
            Active = false;
            ModifiedAt = DateTime.UtcNow;
        }

        public abstract ResponseBase GetResponse();

        protected List<ErrorRecord> _errors = new List<ErrorRecord>();
        public IReadOnlyCollection<ErrorRecord> Errors => _errors;
        public abstract bool Validate();
    }
}
