using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // POST: api/Customer
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Register(AddCustomerRequest registerCustomerRequest)
        {
            return Created("uri to retrieve the customer", new Customer());
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            //TODO: Add implementation
            return Ok(new Customer());
        }

        // GET: api/Customer/5/memberships
        [HttpGet("{id}/memberships")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerMembershipDetails>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMembershipByCustomerId(int id)
        {
            //TODO: Add implementation
            //should return valid membership details, not past ones
            return Ok(new List<CustomerMembershipDetails>());
        }

        // GET: api/Customer/5/products
        [HttpGet("{id}/products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductsByCustomerId(int id)
        {
            //TODO: Add implementation
            //should return bought products like e-books and videos, but not physical orders or membership details
            return Ok(new List<Product>());
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCustomerProfile(int id, AddCustomerRequest customerRequest)
        {
            if (id != customerRequest.Id)
            {
                return BadRequest();
            }

            //TODO: Add implementation
            return Ok();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            //TODO: Add implementation
            return Ok();
        }
    }
}
