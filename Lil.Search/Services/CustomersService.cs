using System.Text.Json;
using System.Text.Json.Serialization;
using Lil.Search.Interfaces;
using Lil.Search.Models;

namespace Lil.Sales.Services
{
    public class CustomersService(IHttpClientFactory httpClientFactory) : ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

        public async Task<Customer> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("customersService");
            var res = await client.GetAsync($"api/customers/{id}");

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var customer = JsonSerializer.Deserialize<Customer>(content);
                return customer;

            }
            return null;
        }
    }
}