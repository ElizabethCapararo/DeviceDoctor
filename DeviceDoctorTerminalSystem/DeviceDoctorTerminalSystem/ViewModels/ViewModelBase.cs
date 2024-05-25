using DeviceDoctorTerminalSystem.Support;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace PointOfSaleTerminalSystem.ViewModels
{
    public abstract class ViewModelBase : NotifyPropertyChanged
    {
        public string Title { get; }

        public ICommand LoadCommand { get; }

        public ViewModelBase(string title)
        {
            Title = title;
            LoadCommand = new AsyncRelayCommand(OnLoad);
        }

        public virtual Task OnLoad() => Task.CompletedTask;
    }
}
