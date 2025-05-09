using FluentValidation;
using GTS.TaskManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS.TaskManagement.Shared.Validators
{
    public class ToDoPriorityFilterValidator : AbstractValidator<ToDoPriorityFilter>
    {
        public ToDoPriorityFilterValidator()
        {
            RuleFor(x => x.Priority)
                .NotEmpty()
                .WithMessage("Priority cannot be empty.")
                .Must(ValidatorsHelpers.IsValidPriority)
                .WithMessage("Priority must be one of the following: Low, Medium, High.");
        }
    }
}
