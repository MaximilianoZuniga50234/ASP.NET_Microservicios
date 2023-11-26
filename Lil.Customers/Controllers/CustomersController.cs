using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomersProvider customersProvider) : ControllerBase
    {
        private readonly ICustomersProvider customersProvider = customersProvider;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var customer = await customersProvider.GetAsync(id);

            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }
    }
}