using FluentValidation;
using ToDoList.Domain.Lists;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Exceptions;
using ToDoList.Domain.Tasks.Responses;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Records;
using static ToDoList.Shared.Helpers.ErroCodeHelper;

namespace ToDoList.Domain.Tasks.Enitities
{
    public enum WorkflowStatus { 
        TODO, DOING, DONE
    }
    public class TaskEntity: EntityBase
    {
        public TaskEntity():base()
        {            
        }
        public TaskEntity(ListEntity list, string title):base()
        {
            List = list;
            Title = title; 
            Status = WorkflowStatus.TODO;
        }

        public TaskEntity(ListEntity list, string title, string url) : base()
        {
            List = list;
            Title = title;
            URL = url;
            Status = WorkflowStatus.TODO;
        }

        public TaskEntity(ListEntity list, string title, string url, string description) : base()
        {
            List = list;
            Title = title;
            URL = url;
            Description = description;
            Status = WorkflowStatus.TODO;
        }

        public void AddList(ListEntity list) 
        {
            List = list;            
        }
        public void Change(string title, string url, string description) 
        {            
            Title = title;
            URL = url;
            Description = description;
            Status = WorkflowStatus.TODO;
            
        }

        public void AddPeriod(DateTime? startAt, DateTime? endAt)
        {
            if (startAt != null) startAt = DateTime.SpecifyKind(startAt.GetValueOrDefault(), DateTimeKind.Utc);
            if (endAt != null) startAt = DateTime.SpecifyKind(endAt.GetValueOrDefault(), DateTimeKind.Utc);

            StartAt = startAt;
            EndAt = endAt;
        }

        public void GoNextStatus()
        { 
            if (Status == WorkflowStatus.TODO) 
                Status = WorkflowStatus.DOING;
            else if (Status == WorkflowStatus.DOING)
                Status = WorkflowStatus.DONE;            

        }

        public void ChangeStatus(WorkflowStatus status)
        {
            //if (Status == status)
            //    throw new Exception();

            Status = status;
        }

        public ListEntity List { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string URL { get; private set; }

        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; private set; }

        public WorkflowStatus Status { get; set; }

        public override TaskResponse GetResponse()
        {
            return new TaskResponse { 
                Id = Id,
                Title = Title,
                StartAt = StartAt,
                EndAt = EndAt,
                Url = URL,
                Description = Description,

            };
        }

        public override bool Validate()
        {
            var validator = new TaskValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(
                        error.ErrorCode == null ? error.ErrorMessage : error.ErrorCode
                        , error.ErrorMessage));
                throw new TaskException(_errors);
            }
            return true;
        }

        private class TaskValidator : AbstractValidator<TaskEntity>
        {

            public TaskValidator()
            {

                RuleFor(x => x.Title).NotEmpty().WithErrorCode(ERROR_TASK_TITLE_001);
                RuleFor(x => x.Title).MaximumLength(120).WithErrorCode(ERROR_TASK_TITLE_002);
                RuleFor(x => x.Description).MaximumLength(500).WithErrorCode(ERROR_TASK_DESCRIPTION_003);
                RuleFor(x => x.URL).MaximumLength(2083).WithErrorCode(ERROR_TASK_URL_004);
                RuleFor(x => x.Status).NotNull().WithErrorCode(ERROR_TASK_URL_004);
                RuleFor(x => new { StartAt = x.StartAt, EndAt = x.EndAt })
                    .Custom((value, context) =>
                    {
                        if (value.StartAt != null 
                                && value.StartAt.GetValueOrDefault() < DateTime.UtcNow )
                            context.AddFailure(ERROR_TASK_STARTAT_006);

                        if (value.EndAt != null
                                && value.EndAt.GetValueOrDefault() < DateTime.UtcNow)
                            context.AddFailure(ERROR_TASK_ENDAT_007);

                        if (value.StartAt != null && value.EndAt != null
                                && value.EndAt.GetValueOrDefault() < value.StartAt.GetValueOrDefault())
                            context.AddFailure(ERROR_TASK_STARTENDAT_008);
                    });



            }

        }
    }
}
