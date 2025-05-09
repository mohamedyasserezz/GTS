using FluentValidation;
using GTS.TaskManagement.Shared.Models;
namespace GTS.TaskManagement.Shared.Validators
{ 
    public class ToDoUpdateRequestValidator : AbstractValidator<ToDoUpdateRequest>
    {
        public ToDoUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Priority)
                .NotEmpty()
                .WithMessage("Priority is required.")
                .Must(ValidatorsHelpers.IsValidPriority)
                .WithMessage("Priority must be one of the following: Low, Medium, High.");


            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required.")
                .Must(ValidatorsHelpers.IsValidStatus)
                .WithMessage("Status must be one of the following: InProgress, Pending, Completed.");

            When(x => x.DueDate.HasValue, () =>
            {
                RuleFor(x => x.DueDate)
                    .Must(ValidatorsHelpers.BeAValidDueDate)
                    .WithMessage("Due date must be a valid date.");
            });
            
        }
    }
}


