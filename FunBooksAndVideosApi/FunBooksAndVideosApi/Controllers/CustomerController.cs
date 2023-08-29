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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(new Customer());
        }

        [HttpGet("{id}/memberships")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerMembershipDetails>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMembershipByCustomerId(int id)
        {
            return Ok(new List<CustomerMembershipDetails>());
        }

        [HttpGet("{id}/products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductsByCustomerId(int id)
        {
            return Ok(new List<Product>());
        }

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

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok();
        }
    }
}
