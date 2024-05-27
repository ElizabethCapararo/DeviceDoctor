using DeviceDoctorTerminalSystem.Utilities;
using Microsoft.Toolkit.Mvvm.Input;
using PointOfSaleTerminalSystem.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<string> History { get; } = new();

        public string LogEntry
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand SubmitLogCommand { get; set; }

        public RepairHistoryViewModel(List<string> history) : base()
        {
            SubmitLogCommand = new RelayCommand(SubmitLog, () => !string.IsNullOrEmpty(LogEntry));
            history.ForEach(History.Add);
        }

        private void SubmitLog()
        {
            History.Add(LogEntry.ToFormattedLogEntry());
            LogEntry = string.Empty;
        }
    }
}
