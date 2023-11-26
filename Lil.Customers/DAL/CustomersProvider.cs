using Lil.Customers.Models;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> Repo = [];

        public CustomersProvider()
        {
            Repo.Add(new Customer() { Id = "1", Name = "Rodrigo", City = "Mendoza" });
            Repo.Add(new Customer() { Id = "2", Name = "Martín", City = "Mendoza" });
            Repo.Add(new Customer() { Id = "3", Name = "Laura", City = "Córdoba" });
            Repo.Add(new Customer() { Id = "4", Name = "Lucía", City = "San Juan" });
        }
        public Task<Customer> GetAsync(string id)
        {
            var customer = Repo.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }
    }
}