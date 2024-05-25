using Newtonsoft.Json;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public static class JsonUtility
    {
        public static string Serialize<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static T Deserialize<T>(this string stringObj) where T : new() => JsonConvert.DeserializeObject<T>(stringObj) ?? new T();
    }
}
