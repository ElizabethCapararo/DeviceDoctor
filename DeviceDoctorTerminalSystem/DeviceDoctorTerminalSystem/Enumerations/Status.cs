using System.ComponentModel;

namespace DeviceDoctorTerminalSystem.Enumerations
{
    public enum Status
    {
        [Description("Triaged")]
        Triaged,

        [Description("In Progress")]
        InProgress,

        [Description("Completed")]
        Completed,

        [Description("Cancelled")]
        Cancelled
    }
}
