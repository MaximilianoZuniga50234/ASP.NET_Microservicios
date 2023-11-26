using System.Text.Json;
using Lil.Search.Interfaces;
using Lil.Search.Models;

namespace Lil.Sales.Services
{
    public class ProductsService(IHttpClientFactory httpClientFactory) : IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

        public async Task<Product> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productsService");
            var res = await client.GetAsync($"api/products/{id}");

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(content);
                return product;
            }
            return null;
        }
    }
}