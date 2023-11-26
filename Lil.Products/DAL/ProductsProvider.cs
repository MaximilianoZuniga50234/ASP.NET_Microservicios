using Lil.Products.Models;

namespace Lil.Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly List<Product> Repo = [];
        public ProductsProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                Repo.Add(new Product()
                {
                    Id = (i + 1).ToString(),
                    Name = $"Producto {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }

        public Task<Product> GetAsync(string id)
        {
            var product = Repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}