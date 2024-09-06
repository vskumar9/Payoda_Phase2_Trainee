using API_Application.Models;
using API_Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin, User")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _service.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<Employee> Get(int id)
        {
            return await _service.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task Post(Employee employee)
        {
            await _service.AddEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Put(int id, Employee employee)
        {
            await _service.UpdateEmployee(id, employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Delete(int id)
        {
            await _service.DeleteEmployee(id);
        }
    }
}
