using System.Text.Json;
using Lil.Search.Interfaces;
using Lil.Search.Models;

namespace Lil.Sales.Services
{
    public class SalesService(IHttpClientFactory httpClientFactory) : ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = httpClientFactory.CreateClient("salesService");
            var res = await client.GetAsync($"api/sales/{customerId}");

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<ICollection<Order>>(content);
                return orders;
            }
            return null;
        }
    }
}