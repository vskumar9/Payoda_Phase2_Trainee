using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly AdminService _service;

        public AdminController(AdminService service)
        {
            _service = service;
        }



        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Admin admin)
        {
            var adminResult = await _service.RegisterAdmin(admin);
            if (adminResult == null) return BadRequest();
            else if (adminResult.Contains("Exist")) return Ok("Already Existed.");
            else if (adminResult != null && !adminResult.Contains("Exist")) return CreatedAtAction("Get", new { id = admin.AdminId }, admin);
            return Ok(adminResult);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
