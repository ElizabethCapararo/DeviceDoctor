using DeviceDoctorTerminalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceDoctorTerminalSystem.Database
{
    public class DocDbContext : DbContext, IDocDbContext
    {
        DbSet<Repair> Repairs { get; set; }

        IEnumerable<T> IDocDbContext.All<T>() where T : class => Set<T>().AsQueryable();

        T? IDocDbContext.Get<T>(Func<T, bool> condition) where T : class => Set<T>().FirstOrDefault(condition);

        void IDocDbContext.Remove<T>(T entity) => Set<T>().Remove(entity);

        void IDocDbContext.Add<T>(T entity) where T : class => Set<T>().Add(entity);

        public async Task UpdateDatabase(Action performAction)
        {
            using var transaction = Database.BeginTransaction();
            var savePointKey = "Pre-Transaction";
            await transaction.CreateSavepointAsync(savePointKey);

            try
            {
                performAction();
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint(savePointKey);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DevDocDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();
                e.OwnsOne(e => e.Device);
                e.Navigation(e => e.Customer).AutoInclude();
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
