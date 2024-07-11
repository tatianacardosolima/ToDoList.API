using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Exceptions;
using ToDoList.Shared.Records;

namespace ToDoList.Domain.Lists
{
    public class ListException : DomainException
    {
        public ListException(string code, string message) : base(code, message)
        {
        }
        public ListException(List<ErrorRecord> _errors) : base(_errors) { }

        public static new void ThrowWhen(bool invalidRule, string code, string message)
        {
            if (invalidRule) throw new ListException(code, message);
        }
    }
}
