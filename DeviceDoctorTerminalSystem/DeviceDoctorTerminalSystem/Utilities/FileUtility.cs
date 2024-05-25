using System.IO;
using System.Text;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public class FileUtility
    {
        public static void Write(string path, string fileName, string content)
        {
            using StreamWriter file = new StreamWriter(Path.Combine(path, fileName));
            file.Write(content);
        }

        public static string Read(string path, string fileName)
        {
            using StreamReader streamReader = new StreamReader(Path.Combine(path, fileName), Encoding.UTF8);
            return streamReader.ReadToEnd();
        }
    }
}
