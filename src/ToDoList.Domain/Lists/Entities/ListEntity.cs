using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Responses;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Helpers;
using ToDoList.Shared.Interfaces;
using ToDoList.Shared.Records;
using static ToDoList.Shared.Helpers.ErroCodeHelper;

namespace ToDoList.Domain.Lists.Entities
{
    public class ListEntity: EntityBase
    {
        public string Name { get; private set; }

        public ListEntity(string name): base()
        {
            Name = name;
        }
        public ListEntity() 
        {            
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public override ListResponse GetResponse()
        {
            return new ListResponse()
            {
                Id = Id,
                Name = Name,
            };
        }

        public override bool Validate()
        {
            var validator = new ListValidator ();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(
                        error.ErrorCode == null ? error.ErrorMessage : error.ErrorCode
                        , error.ErrorMessage));
                throw new ListException(_errors);
            }
            return true;

        }

        private class ListValidator : AbstractValidator<ListEntity>
        {

            public ListValidator()
            {

                RuleFor(x => x.Name).NotEmpty().WithErrorCode(ERROR_LIST_NAME_001);

                RuleFor(x => x.Name).MaximumLength(180).WithErrorCode(ERROR_LIST_NAME_002);
                

            }

        }
    }
}
