using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Utilities;
using Microsoft.Toolkit.Mvvm.Input;
using PointOfSaleTerminalSystem.ViewModels;
using System.Windows.Input;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairActionViewModel : ViewModelBase
    {
        public ICommand ActionCommand { get; init; }

        public RepairActionViewModel(RepairAction repairAction, Func<Task> performAction) 
            : base(repairAction.Description())
        {
            ActionCommand = new AsyncRelayCommand(performAction);
        }
    }
}
