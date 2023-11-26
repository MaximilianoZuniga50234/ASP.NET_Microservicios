using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsProvider productsProvider) : ControllerBase
    {
        private readonly IProductsProvider productsProvider = productsProvider;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await productsProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}