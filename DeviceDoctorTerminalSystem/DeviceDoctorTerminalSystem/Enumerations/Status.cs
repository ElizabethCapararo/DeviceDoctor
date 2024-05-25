using System.ComponentModel;

namespace DeviceDoctorTerminalSystem.Enumerations
{
    public enum Status
    {
        [Description("TRIAGED")]
        Triaged,

        [Description("IN PROGRESS")]
        InProgress,

        [Description("COMPLETED")]
        Completed,

        [Description("CANCELLED")]
        Cancelled
    }
}
