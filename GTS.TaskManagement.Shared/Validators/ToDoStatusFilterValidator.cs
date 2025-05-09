using FluentValidation;
using GTS.TaskManagement.Shared.Models;

namespace GTS.TaskManagement.Shared.Validators
{
    public class ToDoStatusFilterValidator : AbstractValidator<ToDoStatusFilter>
    {
        public ToDoStatusFilterValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status cannot be empty.")
                .Must(ValidatorsHelpers.IsValidStatus)
                .WithMessage("Status must be one of the following: InProgress, Pending, Completed.");
        }
    }
}
