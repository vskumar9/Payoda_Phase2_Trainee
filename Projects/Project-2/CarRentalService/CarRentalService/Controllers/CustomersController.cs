using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;
        public CustomersController(CustomerService service)
        {
            _service = service;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var customerResult = await _service.RegisterCustomer(customer);
            if (customerResult == null) return BadRequest();
            else if (customerResult.Contains("Exist")) return Ok("Already Existed.");
            else if (customerResult != null && !customerResult.Contains("Exist")) return CreatedAtAction("Get", new { id = customer.CustomerId }, customer);
            return Ok(customerResult);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
