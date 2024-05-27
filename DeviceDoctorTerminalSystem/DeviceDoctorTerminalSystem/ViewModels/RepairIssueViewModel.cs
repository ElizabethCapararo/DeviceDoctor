using PointOfSaleTerminalSystem.ViewModels;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairIssueViewModel : BaseViewModel
    {        
        public string? IssueDescription { get; set; }

        public RepairIssueViewModel(string issueDescription) : base()
        {
            IssueDescription = issueDescription;
        }
    }
}
