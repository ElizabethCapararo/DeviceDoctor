using DeviceDoctorTerminalSystem.Database;
using DeviceDoctorTerminalSystem.Models;

namespace DeviceDoctorTerminalSystem.Services
{
    public class CustomerService
    {
        private readonly IDocDbContext context;

        public CustomerService(IDocDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<List<Customer>> GetCustomers() =>
            context.All<Customer>().ToList();

        public Customer ResolveExistingCustomer(Customer customer) =>
            context.Get<Customer>(c => c.Id == customer.Id) ??
                context.Get<Customer>(c =>
                    c.FirstName == customer.FirstName &&
                    c.LastName == customer.LastName &&
                    c.ContactNumber == customer.ContactNumber) ??
                    customer;
    }
}
