using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(ISalesProvider salesProvider) : ControllerBase
    {
        private readonly ISalesProvider salesProvider = salesProvider;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var orders = await salesProvider.GetAsync(id);
            if (orders != null && orders.Count != 0)
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }
}