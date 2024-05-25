using DeviceDoctorTerminalSystem.Database;
using DeviceDoctorTerminalSystem.Models;

namespace DeviceDoctorTerminalSystem.Services
{
    public class RepairService
    {
        private readonly IDocDbContext context;

        public RepairService(IDocDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Repair> GetRepairs() => context.All<Repair>().ToList();

        public async Task CompleteRepair(Repair repair) => 
            await context.UpdateDatabase(() => context.Get<Repair>(r => r.Id == repair.Id).Complete());

        public async Task DeleteRepair(Repair repair) => 
            await context.UpdateDatabase(() => context.Remove(repair));

        public async void UpdateRepair(Repair repair)
        {
            await context.UpdateDatabase(() =>
            {
                var existingRepair = context.Get<Repair>(r => r.Id == repair.Id);
                if (existingRepair == null)
                {
                    context.Add(repair);
                }
                else
                {
                    repair.UpdateLog("Repair details updated");
                }
            });
        }        
    }
}
