using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists;
using ToDoList.Shared.Exceptions;
using ToDoList.Shared.Records;

namespace ToDoList.Domain.Tasks.Exceptions
{
    public class TaskException: DomainException
    {
        public TaskException(string code, string message) : base(code, message)
        {
        }
        public TaskException(List<ErrorRecord> _errors) : base(_errors) { }

        public static new void ThrowWhen(bool invalidRule, string code, string message)
        {
            if (invalidRule) throw new ListException(code, message);
        }
    }
}
