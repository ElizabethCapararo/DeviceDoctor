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

        public async Task<List<Repair>> GetRepairs()
        {
            await Task.CompletedTask;

            return new List<Repair>()
            {
                Repair.Create(
                    Customer.Create("David", "Emery", "0425791172"),
                    Device.Create("XYZ192M1234", "S4", "Samsung", "Cracked screen"),
                    "Black screen, no signs of life")
            };
        }
    }
}
