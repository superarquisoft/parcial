using System.ComponentModel;

namespace Domain.Models.Enums
{
    public enum ExceptionsDetail
    {
        [Description("Unhandled business exception.")]
        UnhandledException = 1,

        [Description("User not found")]
        UserNotFound = 2
    }
}
