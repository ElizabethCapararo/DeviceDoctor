using DeviceDoctorTerminalSystem.Models;
using PointOfSaleTerminalSystem.ViewModels;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairCustomerViewModel : BaseViewModel
    {
        public Customer Customer { get; }

        public RepairCustomerViewModel(Customer customer) : base()
        {
            Customer = customer;
        }
    }
}
