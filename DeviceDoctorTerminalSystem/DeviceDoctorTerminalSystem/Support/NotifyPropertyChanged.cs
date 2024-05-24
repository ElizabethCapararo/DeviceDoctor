using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeviceDoctorTerminalSystem.Support
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        private Dictionary<string, object> _values = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Set<T>(T value, [CallerMemberName] string memberName = null)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return;
            }

            if (_values.ContainsKey(memberName))
            {
                _values[memberName] = value;
                return;
            }

            _values.Add(memberName, value);
            NotifyChanged();
        }

        public T Get<T>([CallerMemberName] string memberName = null)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                throw new ArgumentOutOfRangeException(nameof(memberName));
            }

            if (!_values.ContainsKey(memberName))
            {
                _values.Add(memberName, default(T));
            }

            return (T)_values[memberName];
        }

        protected void NotifyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
