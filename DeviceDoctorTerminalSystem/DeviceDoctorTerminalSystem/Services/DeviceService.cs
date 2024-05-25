using DeviceDoctorTerminalSystem.Database;
using DeviceDoctorTerminalSystem.Models;

namespace DeviceDoctorTerminalSystem.Services
{
    public class DeviceService
    {
        private readonly IDocDbContext context;

        public DeviceService(IDocDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<List<Device>> GetDevices()
        {
            await Task.CompletedTask;

            return new List<Device>()
            {
                Device.Create(
                    Customer.Create("David", "Emery", "0425791172"),
                    "XYZ192M1234",
                    "S4",
                    "Samsung",
                    "Black screen, no signs of life",
                    "Cracked screen")
            };
        }
    }
}
