using System.ComponentModel;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public static class EnumUtility
    {
        public static string Description<T>(this T value) where T : Enum =>
            value?.GetAttribute<T, DescriptionAttribute>()?.Description ??
                value?.ToString() ??
                string.Empty;

        private static TS? GetAttribute<T, TS>(this T value)
            where T : Enum
            where TS : Attribute => value?.GetType()
                    .GetField(value?.ToString() ?? string.Empty)?
                    .GetCustomAttributes(typeof(TS), false)
                    .SingleOrDefault() as TS;
    }
}
