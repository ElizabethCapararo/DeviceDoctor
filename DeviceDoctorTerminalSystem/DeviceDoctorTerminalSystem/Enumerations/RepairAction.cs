using System.ComponentModel;

namespace DeviceDoctorTerminalSystem.Enumerations
{
    public enum RepairAction
    {
        [Description("New Repair")]
        RegisterNewRepair,

        [Description("Save Changes")]
        SaveChangesToRepair,

        [Description("Complete Repair")]
        CompleteRepair,

        [Description("Cancel Repair")]
        CancelRepair,

        [Description("Delete Repair")]
        DeleteRepair
    }
}
