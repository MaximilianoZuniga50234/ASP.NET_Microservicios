using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        public readonly List<Order> repo = [];
        public SalesProvider()
        {
            repo.Add(new Order()
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>(){
                    new(){OrderId = "0001", Id = 1, Price = 50, ProductId = "23", Quantity = 2},
                    new(){OrderId = "0001", Id = 2, Price = 50, ProductId = "24", Quantity = 2}
                }
            });
            repo.Add(new Order()
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-4),
                Total = 50,
                Items = new List<OrderItem>(){
                    new(){OrderId = "0002", Id = 1, Price = 20, ProductId = "10", Quantity = 1},
                    new(){OrderId = "0002", Id = 2, Price = 30, ProductId = "55", Quantity = 1}
                }
            });
            repo.Add(new Order()
            {
                Id = "0003",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-3),
                Total = 150,
                Items = new List<OrderItem>(){
                    new(){OrderId = "0003", Id = 1, Price = 150, ProductId = "41", Quantity = 3}
                }
            });
            repo.Add(new Order()
            {
                Id = "0004",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddMonths(-8),
                Total = 200,
                Items = new List<OrderItem>(){
                    new(){OrderId = "0004", Id = 1, Price = 100, ProductId = "78", Quantity = 1},
                    new(){OrderId = "0004", Id = 2, Price = 100, ProductId = "66", Quantity = 2}
                }
            });
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(o => o.CustomerId == customerId).ToList();
            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}