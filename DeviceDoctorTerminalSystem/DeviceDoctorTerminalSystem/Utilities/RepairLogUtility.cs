using DeviceDoctorTerminalSystem.Models;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public static class RepairLogUtility
    {
        public static string ToFormattedLogEntry(this string entry) => $"{DateTime.Now}: {entry}";

        public static void Log(this Repair repair, string entry) => 
            repair.Updates.Add(entry.ToFormattedLogEntry());
    }
}
