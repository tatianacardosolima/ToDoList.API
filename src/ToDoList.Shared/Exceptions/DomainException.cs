using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Records;

namespace ToDoList.Shared.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DomainException: Exception
    {
        public IReadOnlyCollection<ErrorRecord> Errors;
        public string Code { get; init; }
        public DomainException(string code, string message) : base(message)
        {
            Code = code;
        }

        public DomainException(string message) :base(message)
        {            
        }

        public DomainException(List<ErrorRecord> _errors) : base(_errors.FirstOrDefault()?.Message)
        {
            Errors = _errors;
            Code = _errors.ElementAt(0).Code;
            //Message = _errors.ElementAt(0).Message;
        }
        public static void ThrowWhen(bool invalidRule, string message)
        {
            if (invalidRule)
            {
                throw new DomainException(message);
            }
        }

        public static void ThrowWhenThereAreErrorMessages(IEnumerable<ValidationResult> validationResults)
        {
            if (validationResults.Any())
            {
                throw new DomainException(validationResults.ElementAt(0).ErrorMessage);
            }
        }
    }
}
