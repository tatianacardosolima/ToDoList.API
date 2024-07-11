using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared.Records
{
    public record ErrorRecord(string Code, string Message)
    {
    }
}
