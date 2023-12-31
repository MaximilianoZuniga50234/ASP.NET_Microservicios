using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ICustomersService customersService, IProductsService productsService, ISalesService salesService) : ControllerBase
    {
        private readonly ICustomersService customersService = customersService;
        private readonly IProductsService productsService = productsService;
        private readonly ISalesService salesService = salesService;

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {

            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest();
            }

            try
            {
                var customer = await customersService.GetAsync(customerId);
                var sales = await salesService.GetAsync(customerId);

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await productsService.GetAsync(item.ProductId);
                        item.Product = product;
                    }
                }

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };
                return Ok(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}