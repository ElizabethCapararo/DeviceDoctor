using DeviceDoctorTerminalSystem.Database;
using DeviceDoctorTerminalSystem.Models;

namespace DeviceDoctorTerminalSystem.Services
{
    public class RepairService
    {
        private readonly IDocDbContext _context;

        public RepairService(IDocDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<Repair> GetRepairs() => _context.All<Repair>().ToList();
      
        public async Task DeleteRepair(Repair repair) => 
            await _context.UpdateDatabase(() => _context.Remove(repair));

        public async Task UpdateRepair(Repair repair)
        {
            await _context.UpdateDatabase(() =>
            {
                if (_context.Get<Repair>(r => r.Id == repair.Id) != null)
                {
                    return;
                }
                _context.Add(repair);
            });
        }        
    }
}
