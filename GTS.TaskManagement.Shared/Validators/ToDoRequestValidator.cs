using FluentValidation;
using GTS.TaskManagement.Shared.Models;

namespace GTS.TaskManagement.Shared.Validators
{
    public class ToDoRequestValidator : AbstractValidator<ToDoRequest>
    {
        public ToDoRequestValidator()
        {
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


            When(x => !string.IsNullOrEmpty(x.DueDate), () =>
            {
                RuleFor(x => x.DueDate)
                    .Must(ValidatorsHelpers.BeAValidDueDate)
                    .WithMessage("Due date must be a valid date and be in the future");
            });
        }


        

    }
}
