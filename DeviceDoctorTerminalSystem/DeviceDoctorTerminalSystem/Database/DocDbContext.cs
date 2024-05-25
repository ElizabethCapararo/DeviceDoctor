using DeviceDoctorTerminalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceDoctorTerminalSystem.Database
{
    public class DocDbContext : DbContext, IDocDbContext
    {
        DbSet<Repair> Devices { get; set; }
    }
}
