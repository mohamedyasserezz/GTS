using GTS.TaskManagement.Shared.Consts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS.TaskManagement.Shared.Validators
{
    public static class ValidatorsHelpers
    {
        public static bool BeAValidDueDate(string? dueDate)
        => DateTime.TryParse(dueDate, out var parsedDate) && parsedDate > DateTime.UtcNow;



        public static bool IsValidPriority(string priority)
        => priority == AllowedPriorities.Low ||
                   priority == AllowedPriorities.Medium ||
                   priority == AllowedPriorities.High;
        
        public static bool IsValidStatus(string status)
        => status == AllowedStatus.InProgress ||
                   status == AllowedStatus.Pending ||
                   status == AllowedStatus.Completed;
        
    }
}
